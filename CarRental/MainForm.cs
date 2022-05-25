using System;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CarRental
{
    public partial class MainForm : Form
    {
        // поле - ссылка на экземпляр класса OleDbConnection для соединения с БД
        public static OleDbConnection MyConnection;

        public static UserItem User = null;

        private EmployeesForm employeesForm;
        private ClientsForm clientsForm;
        private GroupsForm groupsForm;
        private BrandsForm brandsForm;
        private ParkingsForm parkingsForm;
        private AutoparkForm autoparkForm;
        private ReportsForm reportsForm;
        private RentalsForm rentalsForm;

        public MainForm()
        {
            InitializeComponent();
            Helper.MainForm = this;
            //allowedOperations = AllowedOperations.None;
        }

        /// <summary>
        /// Обработчик пункта меню "Выход"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Обработчик при закрытии главного окна запрашивает подтверждение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Environment.UserInteractive)
            {
                if (MessageBox.Show(this, "Закрыть программу?", "Подтверждение", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            // закрываем соединение с БД
            MyConnection.Close();
        }

        /// <summary>
        /// Метод, выполняемый при первом запуске программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DisableMenu();
            // создаем экземпляр класса OleDbConnection
            MyConnection = new OleDbConnection(Properties.Settings.Default.СonnectString);
            try
            {
                // открываем соединение с БД
                MyConnection.Open();
                // пробуем войти
                var result = Helper.Login(OnLogin, OnNotEnter);
                if (result == null)
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Ошибка загрузки", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
            }
        }

        public void OnLogin()
        {
            EnableMenu();
            var groupNames = string.Join(", ", User.GroupNames);
            if (string.IsNullOrWhiteSpace(groupNames))
                groupNames = "вне групп";
            lbUser.Text = $"Пользователь {User} ({groupNames})";
        }

        public void OnNotEnter()
        {
            Helper.Logout(() => DisableMenu());
            lbUser.Text = "Пользователь не вошёл";
            btnChangeUser.Enabled = true;
        }

        /// <summary>
        /// Разрешить меню
        /// </summary>
        private void EnableMenu()
        {
            foreach (var menu in menuStripMain.Items.OfType<ToolStripMenuItem>())
                menu.Enabled = true;
            foreach (var item in panelMenu.Controls.OfType<Button>())
                item.Enabled = true;
        }

        /// <summary>
        /// Запретить меню
        /// </summary>
        private void DisableMenu()
        {
            foreach (var menu in menuStripMain.Items.OfType<ToolStripMenuItem>())
                menu.Enabled = false;
            foreach (var item in panelMenu.Controls.OfType<Button>())
                item.Enabled = false;
        }

        /// <summary>
        /// Вызов формы редактирования сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            if (employeesForm == null)
                employeesForm = new EmployeesForm();
            employeesForm.Show();
            if (employeesForm.WindowState == FormWindowState.Minimized)
                employeesForm.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Кнопка "Сменить пользователя"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            Helper.Login(OnLogin, OnNotEnter);
        }

        /// <summary>
        /// Вызов формы редактирования клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClients_Click(object sender, EventArgs e)
        {
            if (clientsForm == null)
                clientsForm = new ClientsForm();
            clientsForm.Show();
            if (clientsForm.WindowState == FormWindowState.Minimized)
                clientsForm.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Вызов формы редактирования групп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccessControl_Click(object sender, EventArgs e)
        {
            if (groupsForm == null)
                groupsForm = new GroupsForm();
            groupsForm.Show();
            if (groupsForm.WindowState == FormWindowState.Minimized)
                groupsForm.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Вызов формы редактирования марок авто
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCarBrands_Click(object sender, EventArgs e)
        {
            ShowBrands();
        }

        /// <summary>
        /// Показать форму редактирования брендов авто
        /// </summary>
        public void ShowBrands(Guid? id = null)
        {
            if (brandsForm == null)
                brandsForm = new BrandsForm();
            brandsForm.Show();
            if (brandsForm.WindowState == FormWindowState.Minimized)
                brandsForm.WindowState = FormWindowState.Normal;
            if (id != null)
                brandsForm.FillTable(id);
        }

        /// <summary>
        /// Вызов формы редактирования парковок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiParking_Click(object sender, EventArgs e)
        {
            ShowParking();
        }

        /// <summary>
        /// Показать форму редактирования парковок
        /// </summary>
        public void ShowParking(Guid? id = null)
        {
            if (parkingsForm == null)
                parkingsForm = new ParkingsForm();
            parkingsForm.Show();
            if (parkingsForm.WindowState == FormWindowState.Minimized)
                parkingsForm.WindowState = FormWindowState.Normal;
            if (id != null)
                parkingsForm.FillTable(id);
        }

        /// <summary>
        /// Вызов формы редактирования парка автомобилей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCarParks_Click(object sender, EventArgs e)
        {
            if (autoparkForm == null)
                autoparkForm = new AutoparkForm();
            autoparkForm.Show();
            if (autoparkForm.WindowState == FormWindowState.Minimized)
                autoparkForm.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Вызов формы редактирования парка автомобилей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiCarParks_Click(object sender, EventArgs e)
        {
            btnCarParks.PerformClick();
        }

        /// <summary>
        /// Вызов формы показа статистики
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            if (reportsForm == null)
                reportsForm = new ReportsForm();
            reportsForm.Show();
            if (reportsForm.WindowState == FormWindowState.Minimized)
                reportsForm.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Вызов формы выдачи или возврата машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeContract_Click(object sender, EventArgs e)
        {
            if (rentalsForm == null)
                rentalsForm = new RentalsForm();
            rentalsForm.Show();
            if (rentalsForm.WindowState == FormWindowState.Minimized)
                rentalsForm.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Перечень автомобилей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiListOfCars_Click(object sender, EventArgs e)
        {
            var wait = new WaitForm();
            wait.Show();
            Cursor = Cursors.WaitCursor;
            dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            var path = Application.StartupPath;
            var templateName = Path.Combine(path, "Reports", "Список.xltx");
            var outputName = Path.Combine(path, "Documents", "Список.xlsx");
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
                var row = 9;
                var query = "SELECT A.[Number], B.[Name] FROM [Autopark] A, [Brands] B WHERE A.[BrandId]=B.[Id] ORDER BY [Number]";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        // в цикле построчно читаем ответ от БД
                        while (reader.Read())
                        {
                            var range1 = sheet.Rows("8:8");
                            range1.Select();
                            sheet.Range("A8").Activate();
                            range1.Copy();
                            sheet.Rows(string.Format($"{row}:{row}")).Select();
                            sheet.Range(string.Format("A{0}", row)).Activate();
                            sheet.Paste();
                            sheet.Cells[row, 2] = reader.GetString(0);  // номер авто
                            sheet.Cells[row, 3] = reader.GetString(1);  // марка авто
                            row++;
                        }
                        var range2 = sheet.Rows("7:8");
                        range2.Select();
                        range2.Delete();
                        sheet.Range("B5").Activate();
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
            MessageBox.Show(this, "Список автомобилей выгружен в папку Documents", "Документы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Выгрузка списка сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiEmployees_Click(object sender, EventArgs e)
        {
            var wait = new WaitForm();
            wait.Show();
            Cursor = Cursors.WaitCursor;
            dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            var path = Application.StartupPath;
            var templateName = Path.Combine(path, "Reports", "Отчет.xltx");
            var outputName = Path.Combine(path, "Documents", "Сотрудники.xlsx");
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
                var row = 2;
                var query = "SELECT [LastName],[FirstName],[SecondName],[AppointmentDate],[Address],[Phone] FROM [Employees] ORDER BY [LastName],[FirstName],[SecondName]";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        sheet.Cells[1, 1] = "Фамилия";
                        sheet.Cells[1, 2] = "Имя";
                        sheet.Cells[1, 3] = "Отчество";
                        sheet.Cells[1, 4] = "Дата регистрации";
                        sheet.Cells[1, 5] = "Адрес";
                        sheet.Cells[1, 6] = "Телефон";
                        // в цикле построчно читаем ответ от БД
                        while (reader.Read())
                        {
                            sheet.Cells[row, 1] = reader.GetString(0);
                            sheet.Cells[row, 2] = reader.GetString(1);
                            sheet.Cells[row, 3] = reader.GetString(2);
                            sheet.Cells[row, 4] = $"{reader.GetDateTime(3):dd.MM.yyyy}";
                            sheet.Cells[row, 5] = reader.GetString(4);
                            sheet.Cells[row, 6] = reader.GetString(5);
                            row++;
                        }
                        sheet.Range("A1").Activate();
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
            MessageBox.Show(this, "Список сотрудников выгружен в папку Documents", "Документы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Выгрузка списка клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiClients_Click(object sender, EventArgs e)
        {
            var wait = new WaitForm();
            wait.Show();
            Cursor = Cursors.WaitCursor;
            dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
            var path = Application.StartupPath;
            var templateName = Path.Combine(path, "Reports", "Отчет.xltx");
            var outputName = Path.Combine(path, "Documents", "Клиенты.xlsx");
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
                var row = 2;
                var query = "SELECT [LastName],[FirstName],[SecondName],[Address],[Passport],[RegistryDate] FROM [Clients] ORDER BY [LastName],[FirstName],[SecondName]";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        sheet.Cells[1, 1] = "Фамилия";
                        sheet.Cells[1, 2] = "Имя";
                        sheet.Cells[1, 3] = "Отчество";
                        sheet.Cells[1, 4] = "Адрес";
                        sheet.Cells[1, 5] = "Паспорт";
                        sheet.Cells[1, 6] = "Дата регистрации";
                        // в цикле построчно читаем ответ от БД
                        while (reader.Read())
                        {
                            sheet.Cells[row, 1] = reader.GetString(0);
                            sheet.Cells[row, 2] = reader.GetString(1);
                            sheet.Cells[row, 3] = reader.GetString(2);
                            sheet.Cells[row, 4] = reader.GetString(3);
                            sheet.Cells[row, 5] = reader.GetString(4);
                            sheet.Cells[row, 6] = $"{reader.GetDateTime(5):dd.MM.yyyy}";
                            row++;
                        }
                        sheet.Range("A1").Activate();
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
            MessageBox.Show(this, "Список клиентов выгружен в папку Documents", "Документы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Вызов формы для оформления договора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiMakeContract_Click(object sender, EventArgs e)
        {
            btnMakeContract.PerformClick();
        }

        /// <summary>
        /// Применение текущих прав пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnAccessControl.Enabled = Helper.AllowedOperations.HasFlag(AllowedOperations.ChangeRights);
            tsmiEmployees.Enabled = btnEmployees.Enabled = Helper.AllowedOperations.HasFlag(AllowedOperations.EmployeesEdit);
            tsmiClients.Enabled = btnClients.Enabled = Helper.AllowedOperations.HasFlag(AllowedOperations.ClientsEdit);
            btnStatistics.Enabled = Helper.AllowedOperations.HasFlag(AllowedOperations.ViewStatistics);
            tsmiCarBrands.Enabled = tsmiParking.Enabled = tsmiListOfCars.Enabled = tsmiCarParks.Enabled = btnCarParks.Enabled = 
                Helper.AllowedOperations.HasFlag(AllowedOperations.GarageEdit);
            tsmiMakeContract.Enabled = btnMakeContract.Enabled = Helper.AllowedOperations.HasFlag(AllowedOperations.FormalizeContracts);
        }
    }
}
