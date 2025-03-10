using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace accountManager {
    public class User {
        public static int CountUsers = 0;

        public int Id { get; set; } = 0;
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }


        public User() : this(null, null, null) {}
        public User(string login, string password, string name) {
            Id = CountUsers++;
            Login = login;
            Password = password;
            Name = name;
        }
        public User(int startId, string login, string password, string name) {
            Id = CountUsers = startId;
            CountUsers++;
            Login = login;
            Password = password;
            Name = name;
        }
    }

    internal class AccountManager {
        List<User> users = new List<User>();
        FileStream fs;
        readonly string _NAMEFILE = "users.txt";
        readonly string _PATH = $@"D:\MyClasses\accountManager\accountManager";
        readonly string FullFilePath = "";
        private readonly Dictionary<string, int> fieldPositions = new Dictionary<string, int> {
            { "ID", 1 },
            { "LOGIN", 3 },
            { "PASSWORD", 5 },
            { "NAME", 7 }
        };
        

        public AccountManager(string nameFile, string path) {
            _NAMEFILE = nameFile;
            _PATH = path;

            FullFilePath = $@"{_PATH}\{_NAMEFILE}";
            LoadUsersFromFile(FullFilePath); 
        }

        // Аутентификация
        public bool Register(string login, string password, string name) {
            for (int i = 0; i < users.Count; i++) {
                if (users[i].Login == login) {
                    Console.WriteLine("A user with this login already exists");
                    return false; 
                }
            }

            users.Add(new User(login, password, name));
            SaveUsersToFile(FullFilePath);
            return true;
        }
        public bool Login(string login, string password) {
            for (int i = 0; i < users.Count; i++)
                if (users[i].Login == login && users[i].Password == password)
                    return true;
            
            return false;
        }


        // Работа с файлами
        private void SaveUsersToFile(string PATH) {
            fs = new FileStream(PATH, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(
                $"ID: {users.Last().Id}, " +
                $"LOGIN: {users.Last().Login}, " +
                $"PASSWORD: {users.Last().Password}, " +
                $"NAME: {users.Last().Name}");

            sw.Close();
            fs.Close();
        }
        private void LoadUsersFromFile(string PATH) {
            fs = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = string.Empty;
            while (!sr.EndOfStream) {
                line = sr.ReadLine();
                string[] tempData = line.Replace(",", "").Split(' ');

                if (line.Length == 0) { continue; }

                users.Add(new User(
                    int.Parse(tempData[fieldPositions["ID"]]),
                    tempData[fieldPositions["LOGIN"]],
                    tempData[fieldPositions["PASSWORD"]],
                    tempData[fieldPositions["NAME"]]
                ));
            }

            sr.Close();
            fs.Close();
        }
        

        // Вывод
        private string PrintColumnInfo() {
            return $"{"ID",-5}{"LOGIN",-10}{"PASSWORD",-10}{"NAME",-15}";
        }
        public string PrintData() {
            string result = PrintColumnInfo() + "\n";
            for (int i = 0; i < users.Count; i++) { result += PrintUserId(i) + "\n"; }
            return result;
        }
        private string PrintUserId(int i) {
            return $"{users[i].Id, -5}{users[i].Login, -10}{users[i].Password, -10}{users[i].Name,-10}";
        }
    }
}