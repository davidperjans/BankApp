using BankApp.Classes.BankAccounts;
using BankApp.Classes.JSON;
using BankApp.Classes.UserFolder;
using Newtonsoft.Json;

namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAppData bankAppData = new BankAppData();

            List<User> users = bankAppData.LoadUsers();

            if (users.Count == 0)
            {
                Console.WriteLine("Finns inga konton, skapa 1 konto i json först");
            }

            UserInterface ui = new UserInterface(users, bankAppData);
            ui.Run();

        }
    }
}
