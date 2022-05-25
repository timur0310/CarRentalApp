using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRental
{
    public partial class RentalsForm : Form
    {
        public RentalsForm()
        {
            InitializeComponent();
            lvTable.ColumnReordered += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanging += (o, e) => { e.Cancel = true; };
            lvTable.ColumnWidthChanged += Helper.LvTable_ColumnWidthChanged;
            lvCars.ColumnReordered += (o, e) => { e.Cancel = true; };
            lvCars.ColumnWidthChanging += (o, e) => { e.Cancel = true; };
            lvCars.ColumnWidthChanged += Helper.LvTable_ColumnWidthChanged;
        }

        private void Rentals_Load(object sender, EventArgs e)
        {
            if (Location.IsEmpty)
                CenterToParent();   // при первом создании форма центрируется
            FillTable();
            FillBrands();
            lbUser.Text = $"Оформляющий сотрудник: {MainForm.User}";
        }

        private void FillBrands()
        {
            // текст запроса
            string query = "SELECT [Id], [Name] FROM [Brands] ORDER BY [Name]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    lbBrands.SelectedItem = null;
                    lbBrands.Items.Clear();
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var item = new ListItem() { Id = reader.GetGuid(0), Name = reader.GetString(1) };
                        lbBrands.Items.Add(item);
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        private void lbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbBrands.SelectedItem == null)
            {
                lvCars.Items.Clear();
            }
            else
            {
                var number = tbCarNumber.Text;
                var brandId = ((ListItem)lbBrands.SelectedItem).Id;
                // текст запроса
                var query = "SELECT [Id],[Number],[Cost] FROM [Autopark] WHERE [BrandId]=@BrandId AND [Number] <> @Number ORDER BY [Cost]";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@BrandId", brandId);
                    command.Parameters.AddWithValue("@Number", number);
                    // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        lvCars.SelectedItems.Clear();
                        lvCars.Items.Clear();
                        // в цикле построчно читаем ответ от БД
                        while (reader.Read())
                        {
                            var lvi = new ListViewItem() { Tag = reader.GetGuid(0) };
                            lvi.Text = $"{lvi.Tag}";
                            lvi.SubItems.Add(reader.GetString(1));
                            lvi.SubItems.Add($"{(decimal)reader.GetValue(2)}");
                            // выводим данные столбцов текущей строки строки в lvTable
                            lvCars.Items.Add(lvi);
                        }
                        // закрываем OleDbDataReader
                        reader.Close();
                     }
                }
            }
        }

        /// <summary>
        /// При закрытии форма скрывается
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rentals_FormClosing(object sender, FormClosingEventArgs e)
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
        public void FillTable(Guid? key = null)
        {
            // текст запроса
            string query = "SELECT A.[Id], B.[LastName], C.[LastName], [RentalDate] " +
                "FROM [Rental] A, [Clients] B, [Employees] C WHERE A.[ClientId]=B.[Id] AND A.[EmployeeId]=C.[Id] ORDER BY [RentalDate]";
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
        /// Заполняем список выбора клиентов
        /// </summary>
        private void FillClients(ComboBox cbox)
        {
            cbox.Items.Clear();
            // текст запроса
            string query = "SELECT [Id], [LastName], [FirstName], [SecondName] FROM [Clients] ORDER BY [LastName], [FirstName], [SecondName]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var item = new ListItem() { Id = reader.GetGuid(0), Name = $"{reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}" };
                        cbox.Items.Add(item);
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        /// <summary>
        /// Заполняем список выбора клиентов
        /// </summary>
        private void FillEmployees(ComboBox cbox)
        {
            cbox.Items.Clear();
            // текст запроса
            string query = "SELECT [Id], [LastName], [FirstName], [SecondName] FROM [Employees] ORDER BY [LastName], [FirstName], [SecondName]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var item = new ListItem() { Id = reader.GetGuid(0), Name = $"{reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}" };
                        cbox.Items.Add(item);
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
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
            var frm = new RentalForm();
            FillClients(frm.cbClients);
            FillEmployees(frm.cbEmployees);
            frm.cbEmployees.SelectedItem = frm.cbEmployees.Items.Cast<ListItem>().FirstOrDefault(item => item.Id == MainForm.User.Id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                string query = "INSERT INTO [Rental] ([Id], [ClientId], [EmployeeId], [CarId], [RentalDate], [ContractComments], [State], [Days]) " +
                    "VALUES (@Id, @ClientId, @EmployeeId, @CarId, @RentalDate, @ContractComments, @State, @Days)";

                var id = Guid.NewGuid();
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@ClientId", ((ListItem)frm.cbClients.SelectedItem).Id);
                    command.Parameters.AddWithValue("@EmployeeId", ((ListItem)frm.cbEmployees.SelectedItem).Id);
                    command.Parameters.AddWithValue("@CarId", Guid.Empty);
                    command.Parameters.AddWithValue("@RentalDate", $"{DateTime.Now}");
                    command.Parameters.AddWithValue("@ContractComments", frm.tbContractComments.Text);
                    command.Parameters.AddWithValue("@State", "");
                    command.Parameters.AddWithValue("@Days", 2);
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
                UpdateProtokolInfo();
                btnReturnAuto.Enabled = btnGiveAuto.Enabled = false;
                tsbChange.Enabled = tsbDelete.Enabled = false;
                pbBrandImage.Image = null;
                tbState.Text = string.Empty;
                tbRentalDays.Text = string.Empty;
                tbRentalDays.ReadOnly = true;
                btnMakeContract.Enabled = false;
                return;
            }
            FillBrands();
            tabControl1.Enabled = true;
            var lvi = lvTable.SelectedItems[0];
            var id = (Guid)lvi.Tag;
            // текст запроса
            string query = "SELECT [CarId],[State],[Days] FROM [Rental] WHERE [Id]=@Id";
            //создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@Id", id);
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var state = reader.GetString(1);
                        tbState.Text = state;
                        btnReturnAuto.Enabled = state == "выдан";
                        tbRentalDays.Text = tbDays.Text = $"{reader.GetInt32(2)}";
                        tbRentalDays.ReadOnly = state != "";
                        var carId = reader.GetGuid(0);
                        if (carId == Guid.Empty)
                        {
                            tabControl1.Enabled = false;
                            UpdateProtokolInfo();
                        }
                        else
                        {
                            tabControl1.Enabled = true;
                            UpdateProtokolInfo(carId);
                        }
                        btnGiveAuto.Enabled = lvCars.SelectedItems.Count == 1;
                        tsbChange.Enabled = tsbDelete.Enabled = string.IsNullOrWhiteSpace(tbState.Text);
                        btnMakeContract.Enabled = tbCarNumber.Enabled;
                        break;
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
        }

        private void UpdateProtokolInfo(Guid? carId = null)
        {
            if (carId == null)
            {
                tbCarNumber.Text = string.Empty;
                tbBrandName.Text = string.Empty;
                tbCarCost.Text = string.Empty;
                tbDays.Text = string.Empty;
                pbPhoto.Image = null;
                tabControl1.Enabled = false;
                btnReturnAuto.Enabled = false;
                GC.Collect();
                return;
            }
            // текст запроса
            string query = "SELECT A.[Number], B.[Name], B.[Image], A.[Cost] FROM [Autopark] A, [Brands] B WHERE A.[Id]=@Id AND A.[BrandId]=B.[Id]";
            //создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@Id", (Guid)carId);
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        tbCarNumber.Text = reader.GetString(0);
                        tbBrandName.Text = reader.GetString(1);
                        tbCarCost.Text = $"{(decimal)reader.GetValue(3)}";
                        var photo = (byte[])reader.GetValue(2);
                        pbPhoto.Image = new Bitmap(new MemoryStream(photo));
                        GC.Collect();
                        break;
                    }
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
            var frm = new RentalForm();
            FillClients(frm.cbClients);
            FillEmployees(frm.cbEmployees);
            // текст запроса
            string query = "SELECT [ClientId], [EmployeeId], [ContractComments] FROM [Rental] WHERE [Id]=@Id";
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
                        frm.cbClients.SelectedItem = frm.cbClients.Items.Cast<ListItem>().FirstOrDefault(item => item.Id == reader.GetGuid(0));
                        frm.cbEmployees.SelectedItem = frm.cbEmployees.Items.Cast<ListItem>().FirstOrDefault(item => item.Id == reader.GetGuid(1));
                        frm.tbContractComments.Text = reader.GetString(2);
                        break;
                    }
                    // закрываем OleDbDataReader
                    reader.Close();
                }
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // текст запроса
                query = "UPDATE [Rental] SET [ClientId]=@ClientId, [EmployeeId]=@EmployeeId, [ContractComments]=@ContractComments WHERE [Id] = @Id";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@ClientId", ((ListItem)frm.cbClients.SelectedItem).Id);
                    command.Parameters.AddWithValue("@EmployeeId", ((ListItem)frm.cbEmployees.SelectedItem).Id);
                    command.Parameters.AddWithValue("@ContractComments", frm.tbContractComments.Text);
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
            if (MessageBox.Show(this, "Удалить позицию договора ренты?", "Удаление", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // текст запроса
                string query = "DELETE FROM [Rental] WHERE [Id] = @Id AND [State]=''";
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
        /// Выбор из таблицы доступных авто изменился
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGiveAuto.Enabled = lvTable.SelectedItems.Count == 1 && lvCars.SelectedItems.Count == 1;
            if (lvCars.SelectedItems.Count != 1)
            {
                pbBrandImage.Image = null;
                return;
            }
            btnGiveAuto.Enabled = string.IsNullOrWhiteSpace(tbState.Text);
            // текст запроса
            string query = "SELECT B.[Image] FROM [Autopark] A, [Brands] B WHERE A.[Id]=@Id AND A.[BrandId]=B.[Id]";
            var lviCar = lvCars.SelectedItems[0];
            var carId = (Guid)lviCar.Tag;
            //создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@Id", carId);
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                var photo = (byte[])command.ExecuteScalar();
                if (photo != null)
                    pbBrandImage.Image = new Bitmap(new MemoryStream(photo));
                else
                    pbBrandImage.Image = null;
            }
        }

        /// <summary>
        /// Нажата кнопка "Выдать авто"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGiveAuto_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1 || lvCars.SelectedItems.Count != 1) return;
            var lviRental = lvTable.SelectedItems[0];
            var lviCar = lvCars.SelectedItems[0];
            var rentalId = (Guid)lviRental.Tag;
            var carId = (Guid)lviCar.Tag;
            // текст запроса
            var query = "UPDATE [Rental] SET [CarId]=@CarId, [State]=@State, [Days]=@Days WHERE [Id]=@Id AND [State]=''";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@CarId", carId);
                command.Parameters.AddWithValue("@State", "выдан");
                command.Parameters.AddWithValue("@Days", long.Parse(tbRentalDays.Text));
                command.Parameters.AddWithValue("@Id", rentalId);
                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
            }
            FillTable(rentalId);
        }

        /// <summary>
        /// Нажата кнопка "Вернуть авто"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReturnAuto_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            var lviRental = lvTable.SelectedItems[0];
            var rentalId = (Guid)lviRental.Tag;
            // текст запроса
            var query = "UPDATE [Rental] SET [State]=@State WHERE [Id]=@Id AND [State]=@OldState";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@State", "возвращён");
                command.Parameters.AddWithValue("@Id", rentalId);
                command.Parameters.AddWithValue("@OldState", "выдан");
                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
            }
            FillTable(rentalId);
        }

        /// <summary>
        /// Проверка правильности ввода количества дней аренды
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbRentalDays_Validated(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            if (long.TryParse(tbDays.Text, out long days) && days > 0)
            {
                var lviRental = lvTable.SelectedItems[0];
                var rentalId = (Guid)lviRental.Tag;
                // текст запроса
                var query = "UPDATE [Rental] SET [Days]=@Days WHERE [Id]=@Id";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (OleDbCommand command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@Days", days);
                    command.Parameters.AddWithValue("@Id", rentalId);
                    // выполняем запрос к MS Access
                    command.ExecuteNonQuery();
                }
                FillTable(rentalId);
            }
        }

        /// <summary>
        /// Выгрузка макета договора в папку Documents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeContract_Click(object sender, EventArgs e)
        {
            if (lvTable.SelectedItems.Count != 1) return;
            var wait = new WaitForm();
            wait.Show();
            Cursor = Cursors.WaitCursor;
            var protokolNumber = lvTable.SelectedItems[0].Index + 1;
            // текст запроса
            string query = @"SELECT E.[LastName],E.[FirstName],E.[SecondName],
C.[LastName],C.[FirstName],C.[SecondName],A.[Number],A.[RegistryDate],
B.[Name],R.[RentalDate],R.[Days],A.[Cost]  
FROM [Rental] R, [Employees] E, [Clients] C, [Autopark] A, [Brands] B 
WHERE R.[Id]=@Id AND R.[EmployeeId] = E.[Id] AND R.[ClientId] = C.[Id] AND R.[CarId] = A.[Id] AND A.[BrandId] = B.[Id]";
            // ключ записи, которую редактируем
            var id = (Guid)lvTable.SelectedItems[0].Tag;
            dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            var path = Application.StartupPath;
            var templateName = Path.Combine(path, "Reports", "Договор аренды.xltx");
            var outputName = Path.Combine(path, "Documents", $"Договор аренды автомобиля №{protokolNumber}.xlsx");
            if (File.Exists(outputName))
            {
                try
                {
                    File.Delete(outputName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, @"Ошибка удаления предыдущей версии таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                var wb = xl.Workbooks.Open(templateName, 0, true);
                var sheet = wb.Sheets[1];

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
                            sheet.Cells[1, 2] = $"Договор на аренду автомобиля   № {protokolNumber}";
                            sheet.Cells[7, 3] = reader.GetString(0);
                            sheet.Cells[8, 3] = reader.GetString(1);
                            sheet.Cells[9, 3] = reader.GetString(2);
                            sheet.Cells[7, 6] = reader.GetString(3);
                            sheet.Cells[8, 6] = reader.GetString(4);
                            sheet.Cells[9, 6] = reader.GetString(5);
                            sheet.Cells[12, 3] = reader.GetString(6);
                            sheet.Cells[12, 7] = $"{reader.GetDateTime(7):dd.MM.yyyy}";
                            sheet.Cells[12, 5] = reader.GetString(8);
                            var days = (int)reader.GetValue(10);
                            sheet.Cells[15, 5] = $"{reader.GetDateTime(9).AddDays(days):dd.MM.yyyy}";
                            var tarif = (decimal)reader.GetValue(11);
                            sheet.Cells[18, 3] = $"{tarif}";
                            sheet.Cells[18, 5] = $"{days}";
                            var total = tarif * days;
                            sheet.Cells[18, 7] = $"Итого: {MoneyToString((double)total)} 00 копеек";
                            break;
                        }
                        // закрываем OleDbDataReader
                        reader.Close();
                    }
                }
                wb.SaveAs(outputName);
                wb.Close();
            }
            finally
            {
                xl.Quit();
                Cursor = Cursors.Default;
                wait.Close();
            }
            MessageBox.Show(this, "Макет договора аренды автомобиля выгружен в папку Documents", "Документы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string MoneyToString(double value)
        {
            var text = value.ToString("000 000 000.00", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            var srub = text.Split('.')[0];
            var skop = text.Split('.')[1];
            var vals = srub.Split(' ');
            var ones = new[] { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
            var teens = new[] { "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
            var tens = new[] { "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            var handreds = new[] { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            var list = new List<string>();
            for (var i = vals.Length - 1; i >= 0; i--)
            {
                var val = vals[i];
                if (i == val.Length - 1)
                {
                    var word = val[2] == '1' ? "рубль" : new[] { '2', '3', '4' }.Contains(val[2]) ? "рубля" : "рублей";
                    list.Insert(0, word);
                }
                if (val != "000")
                {
                    if (i == val.Length - 2)
                    {
                        var word = "тысяч";
                        word += val[2] == '1' ? "а" : new[] { '2', '3', '4' }.Contains(val[2]) ? "и" : "";
                        list.Insert(0, word);
                    }
                    if (i == val.Length - 3)
                    {
                        var word = "миллион";
                        word += val[2] == '1' ? "" : new[] { '2', '3', '4' }.Contains(val[2]) ? "а" : "ов";
                        list.Insert(0, word);
                    }
                }
                if (val[1] == '1')
                {
                    list.Insert(0, teens[int.Parse(val[2].ToString())]);
                }
                else
                {
                    var word = ones[int.Parse(val[2].ToString())];
                    if (i == val.Length - 2)
                        word = val[2] == '1' ? "одна" : val[2] == '2' ? "две" : word;
                    list.Insert(0, word);
                    list.Insert(0, tens[int.Parse(val[1].ToString())]);
                }
                list.Insert(0, handreds[int.Parse(val[0].ToString())]);
            }
            return string.Join(" ", string.Join(" ", list).Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbUser.Text = $"Оформляющий сотрудник: {MainForm.User}";
        }
    }
}
