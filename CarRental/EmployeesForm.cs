using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace CarRental
{
    public partial class EmployeesForm : Form
    {
        public EmployeesForm()
        {
            InitializeComponent();
            lvTable.ColumnReordered += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanging += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanged += Helper.LvTable_ColumnWidthChanged;
        }

        private void EmployeesForm_Load(object sender, EventArgs e)
        {
            if (Location.IsEmpty)
                CenterToParent();   // при первом создании форма центрируется
            FillTable();
        }

        /// <summary>
        /// При закрытии форма скрывается
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Environment.UserInteractive)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /// <summary>
        /// Заполнение таблицы сотрудников
        /// </summary>
        private void FillTable(Guid? key = null)
        {
            // текст запроса
            string query = "SELECT [Id],[LastName],[FirstName],[SecondName],[AppointmentDate] FROM [Employees] ORDER BY [LastName]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    lvTable.SelectedItems.Clear();
                    lvTable.Items.Clear();
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var lvi = new ListViewItem() { Tag = reader.GetGuid(0) };
                        lvi.Text = $"{lvi.Tag}";
                        var user = new UserItem() { LastName = reader.GetString(1), FirstName = reader.GetString(2), SecondName = reader.GetString(3) };
                        lvi.SubItems.Add($"{user}");
                        lvi.SubItems.Add($"{reader.GetDateTime(4):dd.MM.yyyy}");
                        // выводим данные столбцов текущей строки строки в lvTable
                        lvTable.Items.Add(lvi);
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                    // ищем и показываем строку в таблице
                    if (key != null)
                    {
                        var found = lvTable.FindItemWithText($"{key}");
                        if (found != null)
                        {
                            found.Selected = true;
                            lvTable.FocusedItem = found;
                            lvTable.EnsureVisible(found.Index);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Нажата кнопка "Добавить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAppend_Click(object sender, EventArgs e)
        {
            var frm = new EmployeeForm();
            frm.tbAppointmentDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                string query = $"INSERT INTO [Employees] ([Id], [LastName], [FirstName], [SecondName], [AppointmentDate], [Address], [Phone], [PasswordHash])" +
                    $" VALUES (@Id, @LastName, @FirstName, @SecondName, @AppointmentDate, @Address, @Phone, @PasswordHash)";

                var id = Guid.NewGuid();
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@LastName", frm.tbLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", frm.tbFirstName.Text);
                    command.Parameters.AddWithValue("@SecondName", frm.tbSecondName.Text);
                    command.Parameters.AddWithValue("@AppointmentDate", DateTime.Parse(frm.tbAppointmentDate.Text));
                    command.Parameters.AddWithValue("@Address", frm.tbAddress.Text);
                    command.Parameters.AddWithValue("@Phone", frm.tbPhone.Text);
                    command.Parameters.AddWithValue("@PasswordHash", Helper.GetHash("123"));
                    // выполняем запрос к MS Access
                    command.ExecuteNonQuery();
                }
                FillTable(id);
            }
        }

        /// <summary>
        /// Текущая запись в таблице изменилась
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1)
            {
                foreach (var tbox in tabPage1.Controls.OfType<TextBox>())
                    tbox.Text = "";
                btnChangeUser.Enabled = btnChangePassword.Enabled = false;
                tsbChange.Enabled = tsbDelete.Enabled = false;
                return;
            }
            var lvi = lvTable.SelectedItems[0];
            var id = (Guid)lvi.Tag;
            // текст запроса
            string query = "SELECT [LastName], [FirstName], [SecondName], [AppointmentDate], [Address], [Phone] FROM [Employees] WHERE [Id]=@Id";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@Id", id);
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        tbLastName.Text = reader.GetString(0);
                        tbFirstName.Text = reader.GetString(1);
                        tbSecondName.Text = reader.GetString(2);
                        tbAppointmentDate.Text = reader.GetDateTime(3).ToString("dd.MM.yyyy");
                        tbAddress.Text = reader.GetString(4);
                        tbPhone.Text = reader.GetString(5);
                        btnChangeUser.Enabled = btnChangePassword.Enabled = true;
                        tsbChange.Enabled = tsbDelete.Enabled = true;
                        break;
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Нажата кнопка "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbChange_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            var frm = new EmployeeForm();
            // текст запроса
            string query = "SELECT [LastName], [FirstName], [SecondName], [AppointmentDate], [Address], [Phone] FROM [Employees] WHERE [Id]=@Id";
            // ключ записи, которую редактируем
            var id = (Guid)lvTable.SelectedItems[0].Tag;
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@Id", id);
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // читаем только одну запись
                    while (reader.Read())
                    {
                        frm.tbLastName.Text = reader.GetString(0);
                        frm.tbFirstName.Text = reader.GetString(1);
                        frm.tbSecondName.Text = reader.GetString(2);
                        frm.tbAppointmentDate.Text = reader.GetDateTime(3).ToString("dd.MM.yyyy");
                        frm.tbAddress.Text = reader.GetString(4);
                        frm.tbPhone.Text = reader.GetString(5);
                        break;
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                query = "UPDATE [Employees] SET [LastName]=@LastName, [FirstName]=@FirstName, [SecondName]=@SecondName, " +
                    "[AppointmentDate]=@AppointmentDate, [Address]=@Address, [Phone]=@Phone WHERE [Id] = @Id";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@LastName", frm.tbLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", frm.tbFirstName.Text);
                    command.Parameters.AddWithValue("@SecondName", frm.tbSecondName.Text);
                    command.Parameters.AddWithValue("@AppointmentDate", DateTime.Parse(frm.tbAppointmentDate.Text));
                    command.Parameters.AddWithValue("@Address", frm.tbAddress.Text);
                    command.Parameters.AddWithValue("@Phone", frm.tbPhone.Text);
                    command.Parameters.AddWithValue("@Id", id);
                    // выполняем запрос к MS Access
                    command.ExecuteNonQuery();
                }
                FillTable(id);
            }
        }

        /// <summary>
        /// Нажата кнопка "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            if (MessageBox.Show(this, "Удалить позицию сотрудника?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // текст запроса
                string query = "DELETE FROM [Employees] WHERE [Id] = @Id";
                // ключ записи, которую редактируем
                var id = (Guid)lvTable.SelectedItems[0].Tag;
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    // выполняем запрос к MS Access
                    command.ExecuteNonQuery();
                }
                FillTable();
            }
        }

        /// <summary>
        /// Нажата кнопка "Смена пароля"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            var frm = new LoginForm();
            frm.cbEmployee.Items.Add(lvTable.SelectedItems[0].SubItems[1].Text);
            frm.cbEmployee.SelectedIndex = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (Helper.ChangeUserLogin(tbLastName.Text, frm.tbPassword.Text))
                    MessageBox.Show(this, "Пароль изменён успешно", "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(this, "Пароль не изменён", "Изменение пароля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Нажата кнопка "Смена пользователя"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            var result = Helper.Login();
            if (result != null && !(bool)result)
                Close();
        }
    }
}
