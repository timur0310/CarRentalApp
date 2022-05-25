using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace CarRental
{
    public partial class GroupsForm : Form
    {
        public GroupsForm()
        {
            InitializeComponent();
            lvTable.ColumnReordered += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanging += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanged += Helper.LvTable_ColumnWidthChanged;
        }

        private void GroupsForm_Load(object sender, EventArgs e)
        {
            if (Location.IsEmpty)
                CenterToParent();   // при первом создании форма центрируется
            FillTable();
            FillUsers();
        }

        private void FillUsers()
        {
            // текст запроса
            string query = "SELECT [Id], [LastName] FROM [Employees] ORDER BY [LastName]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    lbUsers.Items.Clear();
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        lbUsers.Items.Add(new ListItem() { Id = reader.GetGuid(0), Name = reader.GetString(1) });
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// При закрытии форма скрывается
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupsForm_FormClosing(object sender, FormClosingEventArgs e)
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
            string query = "SELECT [Id], [Descriptor] FROM [Groups] ORDER BY [Descriptor]";
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
            var frm = new GroupForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                string query = $"INSERT INTO [Groups] ([Id], [Descriptor]) VALUES (@Id, @Descriptor)";

                var id = Guid.NewGuid();
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Descriptor", frm.tbDescriptor.Text);
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
                foreach (var cbox in tabPage1.Controls.OfType<CheckBox>())
                    cbox.Checked = false;
                tabControl1.Enabled = false;
                tsbChange.Enabled = tsbDelete.Enabled = false;
                return;
            }
            var lvi = lvTable.SelectedItems[0];
            var id = (Guid)lvi.Tag;
            FillGroupRights(id);
            FillGroupMembers(id);
        }

        /// <summary>
        /// Выборка участников группы
        /// </summary>
        /// <param name="id"></param>
        private void FillGroupMembers(Guid id)
        {
            lbGroupUsers.Items.Clear();
            btnDelete.Enabled = false;
            // текст запроса
            string query = "SELECT B.[Id],B.[LastName],B.[FirstName],B.[SecondName] FROM [GroupEmployees] A, [Employees] B WHERE A.[GroupId]=@Id AND A.[EmployeeId]=B.[Id]";

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
                        lbGroupUsers.Items.Add(new ListItem() 
                        { 
                            Id = reader.GetGuid(0),  
                            Name = $"{reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}"
                        });
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Заполнение прав для группы
        /// </summary>
        /// <param name="id">Идентификатор группы</param>
        private void FillGroupRights(Guid id)
        {
            // текст запроса
            string query = "SELECT [Descriptor],[EnableChangeRights],[EnablePassword],[EnableEmployeesEdit]," +
                "[EnableClientsEdit],[EnableGarageEdit],[FormalizeContracts],[ViewStatistics] FROM [Groups] WHERE [Id]=@Id";

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
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var fieldName = reader.GetName(i);
                            foreach (var cbox in tabPage1.Controls.OfType<CheckBox>())
                            {
                                if (cbox.Name == $"ch{fieldName}")
                                    cbox.Checked = reader.GetBoolean(i);
                            }
                        }
                        tabControl1.Enabled = true;
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
            var frm = new GroupForm();
            // текст запроса
            string query = "SELECT [Descriptor] FROM [Groups] WHERE [Id]=@Id";
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
                        frm.tbDescriptor.Text = reader.GetString(0);
                        break;
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                query = "UPDATE [Groups] SET [Descriptor]=@Descriptor WHERE [Id] = @Id";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Descriptor", frm.tbDescriptor.Text);
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
            if (MessageBox.Show(this, "Удалить позицию группы?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // текст запроса
                string query = "DELETE FROM [Groups] WHERE [Id] = @Id";
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
        /// Нажатие на любом чекбоксе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            var cbox = (CheckBox)sender;
            var fieldName = cbox.Name.Substring(2);
            // текст запроса
            var query = $"UPDATE [Groups] SET [{fieldName}]=@{fieldName} WHERE [Id] = @Id";
            // ключ записи, которую редактируем
            var id = (Guid)lvTable.SelectedItems[0].Tag;
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue($"@{fieldName}", cbox.Checked);
                command.Parameters.AddWithValue("@Id", id);
                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Выбрали какого-то пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }

        /// <summary>
        /// Выбрали пользователя, включенного в группу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGroupUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
        }

        /// <summary>
        /// Нажата кнопка "Добавить" пользователя в группу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            var user = (ListItem)lbUsers.SelectedItem;
            if (user == null) return;
            // текст запроса
            string query = $"INSERT INTO [GroupEmployees] ([Id], [GroupId], [EmployeeId]) VALUES (@Id, @GroupId, @EmployeeId)";

            var groupId = (Guid)lvTable.SelectedItems[0].Tag;
            var id = Guid.NewGuid();

            try
            {
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@GroupId", groupId);
                    command.Parameters.AddWithValue("@EmployeeId", user.Id);
                    // выполняем запрос к MS Access
                    command.ExecuteNonQuery();
                }
                FillGroupMembers(groupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка добавления записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Нажата кнопка "Удалить" пользователя из группы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            var user = (ListItem)lbGroupUsers.SelectedItem;
            if (user == null) return;
            // текст запроса
            string query = "DELETE FROM [GroupEmployees] WHERE [GroupId] = @GroupId AND [EmployeeId] = @EmployeeId";
            var groupId = (Guid)lvTable.SelectedItems[0].Tag;
            try
            {
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@GroupId", groupId);
                    command.Parameters.AddWithValue("@EmployeeId", user.Id);
                    // выполняем запрос к MS Access
                    command.ExecuteNonQuery();
                }
                FillGroupMembers(groupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка удаления записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Нажата кнопка "Удалить все", для очистки приписанных к группе пользователей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            // текст запроса
            string query = "DELETE FROM [GroupEmployees] WHERE [GroupId] = @GroupId";
            var groupId = (Guid)lvTable.SelectedItems[0].Tag;
            try
            {
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@GroupId", groupId);
                    // выполняем запрос к MS Access
                    command.ExecuteNonQuery();
                }
                FillGroupMembers(groupId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка удаления записей", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
