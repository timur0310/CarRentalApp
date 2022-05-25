using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace CarRental
{
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
            lvTable.ColumnReordered += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanging += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanged += Helper.LvTable_ColumnWidthChanged;
        }

        private void ClientsForm_Load(object sender, EventArgs e)
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
        private void ClientsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Environment.UserInteractive)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /// <summary>
        /// Заполнение таблицы клиентов
        /// </summary>
        private void FillTable(Guid? key = null)
        {
            // текст запроса
            string query = "SELECT [Id], [LastName], [FirstName], [SecondName], [RegistryDate] FROM [Clients] ORDER BY [LastName]";
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
                        lvi.SubItems.Add(reader.GetString(1));
                        lvi.SubItems.Add(reader.GetString(2));
                        lvi.SubItems.Add(reader.GetString(3));
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
            var frm = new ClientForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                string query = $"INSERT INTO [Clients] ([Id], [LastName], [FirstName], [SecondName], [Address], [Passport], [RegistryDate])" +
                    $" VALUES (@Id, @LastName, @FirstName, @SecondName, @Address, @Passport, @RegistryDate)";

                var id = Guid.NewGuid();
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@LastName", frm.tbLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", frm.tbFirstName.Text);
                    command.Parameters.AddWithValue("@SecondName", frm.tbSecondName.Text);
                    command.Parameters.AddWithValue("@Address", frm.tbAddress.Text);
                    command.Parameters.AddWithValue("@Passport", frm.tbPassport.Text);
                    command.Parameters.AddWithValue("@RegistryDate", DateTime.Parse(frm.tbRegistryDate.Text));
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
                foreach (var tbox in pnlClientData.Controls.OfType<TextBox>())
                    tbox.Text = "";
                tsbChange.Enabled = tsbDelete.Enabled = false;
                return;
            }
            var lvi = lvTable.SelectedItems[0];
            var id = (Guid)lvi.Tag;
            // текст запроса
            string query = "SELECT [LastName], [FirstName], [SecondName], [Address], [Passport], [RegistryDate] FROM [Clients] WHERE [Id]=@Id";
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
                        tbAddress.Text = reader.GetString(3);
                        tbPassport.Text = reader.GetString(4);
                        tbRegistryDate.Text = reader.GetDateTime(5).ToString("dd.MM.yyyy");
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
            var frm = new ClientForm();
            // текст запроса
            string query = "SELECT [LastName], [FirstName], [SecondName], [Address], [Passport], [RegistryDate] FROM [Clients] WHERE [Id]=@Id";
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
                        frm.tbAddress.Text = reader.GetString(3);
                        frm.tbPassport.Text = reader.GetString(4);
                        frm.tbRegistryDate.Text = reader.GetDateTime(5).ToString("dd.MM.yyyy");
                        break;
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                query = "UPDATE [Clients] SET [LastName]=@LastName, [FirstName]=@FirstName, [SecondName]=@SecondName, " +
                    "[Address]=@Address, [Passport]=@Passport, [RegistryDate]=@RegistryDate WHERE [Id] = @Id";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@LastName", frm.tbLastName.Text);
                    command.Parameters.AddWithValue("@FirstName", frm.tbFirstName.Text);
                    command.Parameters.AddWithValue("@SecondName", frm.tbSecondName.Text);
                    command.Parameters.AddWithValue("@Address", frm.tbAddress.Text);
                    command.Parameters.AddWithValue("@Passport", frm.tbPassport.Text);
                    command.Parameters.AddWithValue("@RegistryDate", DateTime.Parse(frm.tbRegistryDate.Text));
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
            if (MessageBox.Show(this, "Удалить позицию клиента?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // текст запроса
                string query = "DELETE FROM [Clients] WHERE [Id] = @Id";
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
    }
}
