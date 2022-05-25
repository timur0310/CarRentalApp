using System;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace CarRental
{
    public partial class AutoparkForm : Form
    {
        public AutoparkForm()
        {
            InitializeComponent();
            lvTable.ColumnReordered += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanging += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanged += Helper.LvTable_ColumnWidthChanged;
        }

        private void Autopark_Load(object sender, EventArgs e)
        {
            if (Location.IsEmpty)
                CenterToParent();   // при первом создании форма центрируется
            FillTable();
            FillBrands(cbBrands);
            FillParking(cbParking);
        }

        /// <summary>
        /// Заполняем список выбора марок
        /// </summary>
        private void FillBrands(ComboBox cbox)
        {
            cbox.Items.Clear();
            // текст запроса
            string query = "SELECT [Id], [Name] FROM [Brands] ORDER BY [Name]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var item = new ListItem() { Id = reader.GetGuid(0), Name = reader.GetString(1) };
                        cbox.Items.Add(item);
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Заполняем список выбора парковок
        /// </summary>
        private void FillParking(ComboBox cbox)
        {
            cbox.Items.Clear();
            // текст запроса
            string query = "SELECT [Id], [Row] FROM [Parking] ORDER BY [Row]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var item = new ListItem() { Id = reader.GetGuid(0), Name = $"{reader.GetValue(1)}" };
                        cbox.Items.Add(item);
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
        private void Autopark_FormClosing(object sender, FormClosingEventArgs e)
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
            string query = "SELECT A.[Id],A.[Number],B.[Name],A.[RegistryDate],A.[Cost] FROM [Autopark] A, [Brands] B WHERE A.[BrandId]=B.[Id] ORDER BY A.[Cost] DESC";
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
                        lvi.SubItems.Add($"{reader.GetDateTime(3):dd.MM.yyyy}");
                        lvi.SubItems.Add($"{(decimal)reader.GetValue(4)}");
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
            var frm = new AutoForm();
            FillBrands(frm.cbBrands);
            FillParking(frm.cbParking);
            frm.tbRegistryDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                string query = "INSERT INTO [Autopark] ([Id],[BrandId],[ParkingId],[Number],[RegistryDate],[Cost])" +
                    " VALUES (@Id, @BrandId,@ParkingId,@Number,@RegistryDate,@Cost)";

                var id = Guid.NewGuid();
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@BrandId", ((ListItem)frm.cbBrands.SelectedItem).Id);
                    command.Parameters.AddWithValue("@ParkingId", ((ListItem)frm.cbParking.SelectedItem).Id);
                    command.Parameters.AddWithValue("@Number", frm.tbNumber.Text);
                    command.Parameters.AddWithValue("@RegistryDate", DateTime.Parse(frm.tbRegistryDate.Text));
                    command.Parameters.AddWithValue("@Cost", decimal.Parse(frm.tbCost.Text));
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
                cbBrands.SelectedItem = null;
                cbParking.SelectedItem = null;
                cbParking.Enabled = cbBrands.Enabled = btnShowParking.Enabled = btnShowBrands.Enabled = false;
                tsbChange.Enabled = tsbDelete.Enabled = false;
                return;
            }
            var lvi = lvTable.SelectedItems[0];
            var id = (Guid)lvi.Tag;
            // текст запроса
            string query = "SELECT [BrandId],[ParkingId] FROM [Autopark] WHERE [Id]=@Id";
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
                        cbBrands.SelectedItem = cbBrands.Items.Cast<ListItem>().FirstOrDefault(item => item.Id == reader.GetGuid(0));
                        cbParking.SelectedItem = cbParking.Items.Cast<ListItem>().FirstOrDefault(item => item.Id == reader.GetGuid(1));
                        cbParking.Enabled = cbBrands.Enabled = btnShowParking.Enabled = btnShowBrands.Enabled = true;
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
            var frm = new AutoForm();
            FillBrands(frm.cbBrands);
            FillParking(frm.cbParking);
            // текст запроса
            string query = "SELECT [BrandId],[ParkingId],[Number],[RegistryDate],[Cost] FROM [Autopark] WHERE [Id]=@Id";
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
                        frm.cbBrands.SelectedItem = frm.cbBrands.Items.Cast<ListItem>().FirstOrDefault(item => item.Id == reader.GetGuid(0));
                        frm.cbParking.SelectedItem = frm.cbParking.Items.Cast<ListItem>().FirstOrDefault(item => item.Id == reader.GetGuid(1));
                        frm.tbNumber.Text = reader.GetString(2);
                        frm.tbRegistryDate.Text = reader.GetDateTime(3).ToString("dd.MM.yyyy");
                        frm.tbCost.Text = $"{reader.GetDecimal(4)}";
                        break;
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                query = "UPDATE [Autopark] SET [BrandId]=@BrandId, [ParkingId]=@ParkingId, [Number]=@Number, " +
                    "[RegistryDate]=@RegistryDate, [Cost]=@Cost WHERE [Id]=@Id";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@BrandId", ((ListItem)frm.cbBrands.SelectedItem).Id);
                    command.Parameters.AddWithValue("@ParkingId", ((ListItem)frm.cbParking.SelectedItem).Id);
                    command.Parameters.AddWithValue("@Number", frm.tbNumber.Text);
                    command.Parameters.AddWithValue("@RegistryDate", DateTime.Parse(frm.tbRegistryDate.Text));
                    command.Parameters.AddWithValue("@Cost", frm.tbCost.Text);
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
            if (MessageBox.Show(this, "Удалить позицию автомобиля?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // текст запроса
                string query = "DELETE FROM [Autopark] WHERE [Id] = @Id";
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
        /// Выбрана другая марка авто
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBrands_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            if (cbBrands.SelectedItem == null) return;
            // ключ записи, которую редактируем
            var id = (Guid)lvTable.SelectedItems[0].Tag;
            // текст запроса
            var query = "UPDATE [Autopark] SET [BrandId]=@BrandId WHERE [Id]=@Id";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@BrandId", ((ListItem)cbBrands.SelectedItem).Id);
                command.Parameters.AddWithValue("@Id", id);
                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
            }
            FillTable(id);
        }

        /// <summary>
        /// Выбрана другая парковка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbParking_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            if (cbParking.SelectedItem == null) return;
            // ключ записи, которую редактируем
            var id = (Guid)lvTable.SelectedItems[0].Tag;
            // текст запроса
            var query = "UPDATE [Autopark] SET [ParkingId]=@ParkingId WHERE [Id]=@Id";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@ParkingId", ((ListItem)cbParking.SelectedItem).Id);
                command.Parameters.AddWithValue("@Id", id);
                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
            }
            FillTable(id);
        }

        /// <summary>
        /// Показать форму редактирования брендов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowBrands_Click(object sender, EventArgs e)
        {
            if (cbBrands.SelectedItem == null) return;
            Helper.MainForm.ShowBrands(((ListItem)cbBrands.SelectedItem).Id);
        }

        /// <summary>
        /// Показать форму редактирования парковок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowParking_Click(object sender, EventArgs e)
        {
            if (cbParking.SelectedItem == null) return;
            Helper.MainForm.ShowParking(((ListItem)cbParking.SelectedItem).Id);
        }
    }
}
