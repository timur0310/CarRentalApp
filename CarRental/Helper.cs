using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CarRental
{
    public static class Helper
    {
        public static MainForm MainForm;

        /// <summary>
        /// Локальное поле для хранения ограничений для операций
        /// </summary>
        public static AllowedOperations AllowedOperations;

        public static UserItem[] GetEmployees()
        {
            var list = new List<UserItem>();
            // текст запроса
            string query = "SELECT [Id],[LastName],[FirstName],[SecondName] FROM [Employees] ORDER BY [LastName]";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    // в цикле построчно читаем ответ от БД
                    while (reader.Read())
                    {
                        var user = new UserItem()
                        {
                            Id = reader.GetGuid(0),
                            LastName = reader.GetString(1),
                            FirstName = reader.GetString(2),
                            SecondName = reader.GetString(3)
                        };
                        list.Add(user);
                    }
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// Метод входа пользователя
        /// </summary>
        /// <param name="login">Фамилия пользователя</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        private static UserItem UserLoggedIn(UserItem user, string password)
        {
            object id;
            UserItem enteredUser = null;
            // текст запроса
            string query = "SELECT [Id] FROM [Employees] WHERE [LastName]=@LastName AND [PasswordHash]=@PasswordHash";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@PasswordHash", GetHash(password));
                id = command.ExecuteScalar();
            }
            AllowedOperations = AllowedOperations.None; 
            if (id != null)
            {
                enteredUser = user;
                enteredUser.GroupNames.Clear();
                query = @"SELECT [EnableChangeRights],[EnablePassword],[EnableEmployeesEdit],[EnableClientsEdit],[EnableGarageEdit],[FormalizeContracts],[ViewStatistics],[Descriptor] 
FROM [Groups] WHERE [Id] IN (SELECT [GroupId] FROM [GroupEmployees] WHERE [EmployeeId]=@EmployeeId)";
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                using (var command = new OleDbCommand(query, MainForm.MyConnection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", id);
                    // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((bool)reader.GetValue(0))
                                AllowedOperations |= AllowedOperations.ChangeRights;
                            if ((bool)reader.GetValue(1))
                                AllowedOperations |= AllowedOperations.ChangePassword;
                            if ((bool)reader.GetValue(2))
                                AllowedOperations |= AllowedOperations.EmployeesEdit;
                            if ((bool)reader.GetValue(3))
                                AllowedOperations |= AllowedOperations.ClientsEdit;
                            if ((bool)reader.GetValue(4))
                                AllowedOperations |= AllowedOperations.GarageEdit;
                            if ((bool)reader.GetValue(5))
                                AllowedOperations |= AllowedOperations.FormalizeContracts;
                            if ((bool)reader.GetValue(6))
                                AllowedOperations |= AllowedOperations.ViewStatistics;
                            enteredUser.GroupNames.Add(reader.GetString(7));
                        }
                    }
                }
            }
            return enteredUser;
        }

        /// <summary>
        /// Проверка пароля пользователя
        /// </summary>
        /// <returns></returns>
        public static bool? Login(Action preAction = null, Action postAction = null)
        {
            var frm = new LoginForm();
            frm.cbEmployee.Items.AddRange(Helper.GetEmployees());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var user = UserLoggedIn((UserItem)frm.cbEmployee.SelectedItem, frm.tbPassword.Text);
                if (user != null)
                {
                    MainForm.User = user;
                    MainForm.OnLogin();
                    preAction?.Invoke();
                    return true;
                }
                else
                {
                    MainForm.User = null;
                    AllowedOperations = AllowedOperations.None;
                    // выход пользователя с запретом меню
                    postAction?.Invoke();
                    MainForm.OnNotEnter();
                    MessageBox.Show("Пользователь не вошёл", "Вход пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return null;
        }

        /// <summary>
        /// Выход пользователя из системы с выполнением постпроцедуры
        /// </summary>
        /// <param name="postAction"></param>
        public static void Logout(Action postAction = null)
        {
            MainForm.User = null;
            postAction?.Invoke();
        }

        public static string GetHash(string source)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return GetHash(sha256Hash, source);
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
           
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

          
            var sBuilder = new StringBuilder();

           
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            
            return sBuilder.ToString();
        }

        
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            
            var hashOfInput = GetHash(hashAlgorithm, input);

            
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

        /// <summary>
        /// Метод изменения пароля пользователя
        /// </summary>
        /// <param name="login">Фамилия пользователя</param>
        /// <param name="password">Хеш нового пароля</param>
        public static bool ChangeUserLogin(string login, string password)
        {
            // текст запроса
            string query = "UPDATE [Employees] SET [PasswordHash]=@PasswordHash WHERE [LastName]=@LastName";
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            using (var command = new OleDbCommand(query, MainForm.MyConnection))
            {
                command.Parameters.AddWithValue("@PasswordHash", GetHash(password));
                command.Parameters.AddWithValue("@LastName", login);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public static void LvTable_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            var lvTable = (ListView)sender;
            lvTable.ColumnWidthChanged -= LvTable_ColumnWidthChanged;
            try
            {
                lvTable.Columns[0].Width = 0;
            }
            finally
            {
                lvTable.ColumnWidthChanged += LvTable_ColumnWidthChanged;
            }
        }

    }

    [Flags]
    public enum AllowedOperations : uint
    {
        None = 0x0,                 // ничего нельзя
        ChangeRights = 0x1,         // может изменять права доступа
        ChangePassword = 0x2,       // может изменять пароли
        EmployeesEdit = 0x4,        // может редактировать сотрудников
        ClientsEdit = 0x8,          // может редактировать клиентов
        GarageEdit = 0x10,          // может редактировать автопарк
        FormalizeContracts = 0x20,  // может оформлять договора
        ViewStatistics = 0x40,      // может доступ к статистике
        // новые режимы добавлять здесь

        All = 0xffffffff,   // всё можно
    }

    public class UserItem
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public List<string> GroupNames = new List<string>();

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(SecondName))
                return $"{LastName} {FirstName[0]}.{SecondName[0]}.";
            if (!string.IsNullOrWhiteSpace(FirstName) && string.IsNullOrWhiteSpace(SecondName))
                return $"{LastName} {FirstName[0]}.";
            return $"{LastName}";
        }
    }
}
