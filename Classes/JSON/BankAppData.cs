using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Classes.UserFolder;

namespace BankApp.Classes.JSON
{
    public class BankAppData
    {
        private const string UsersFile = "users.json";

        public List<User> LoadUsers()
        {
            if (!File.Exists(UsersFile))
            {
                return new List<User>(); // Return empty if no file
            }

            string json = File.ReadAllText(UsersFile);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(UsersFile, json);
        }

    }
}
