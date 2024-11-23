using BankApp.Classes.JSON;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Classes.UserFolder
{
    public class UserInterface
    {
        private List<User> users;
        private BankAppData data;

        public UserInterface(List<User> users, BankAppData bankAppData)
        {
            this.users = users;
            this.data = bankAppData;
        }

        public void Run()
        {
            var userControl = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Bankapps meny:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[] {
                        "Logga in", "Stäng programmet",
                    }));
            
            switch(userControl)
            {
                case "Logga in":
                    Login();
                    break;
                case "Stäng programmet":
                    Console.WriteLine("allt sparat");
                    data.SaveUsers(users);
                    return;
            }

        }

        public void Login()
        {

            string userName = AnsiConsole.Prompt(new TextPrompt<string>("Enter username:"));
            string passWord = AnsiConsole.Prompt(new TextPrompt<string>("Enter password:"));

            var doesAccountExist = users.FirstOrDefault(user => user.Username == userName && user.Password == passWord); 

            if (doesAccountExist == null)
            {
                Console.WriteLine("Kontot finns inte");
                return;
            }

            PrintMainMenu(doesAccountExist);
            
        }

        public void PrintMainMenu(User user)
        {
            UserManager userManager = new UserManager(user);

            var userControl = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Testing testing")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[] {
                        "Hantera konton", "Inställningar", "Logga ut",
                    }));

            switch (userControl)
            {
                case "Hantera konton":
                    HandleAccountMenu(user);
                    break;
                case "Inställningar":
                    //Logik
                    break;
                case "Logga ut":
                    Console.WriteLine("hejdå");
                    return;
            }
        }

        public void HandleAccountMenu(User user)
        {
            var userControl = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Hantera konton meny:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(new[] {
                        "Visa konton", "Skapa konto", "Ta bort konto", "Gå tillbaka",
                    }));

            switch (userControl)
            {
                case "Visa konton":
                    user.ShowAccounts(user.Accounts);
                    break;
                case "Skapa konto":
                    user.AddAccount();
                    break;
                case "Ta bort konto":
                    //Logik
                    break;
                case "Gå tillbaka":
                    return;
            }
        }
    }
}
