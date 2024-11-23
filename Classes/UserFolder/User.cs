using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankApp.Classes.BankAccounts;

namespace BankApp.Classes.UserFolder
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<BankAccount> Accounts { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Accounts = new List<BankAccount>();
        }

        public void AddAccount()
        {
            string bankAccountName = AnsiConsole.Prompt(new TextPrompt<string>("Enter bankaccount name:"));
            string bankAccountNumber = AnsiConsole.Prompt(new TextPrompt<string>("Enter bankaccount number:"));

            BankAccount newAccount = new BankAccount(bankAccountName, bankAccountNumber, 0);
            Accounts.Add(newAccount);
        }

        public void ShowAccounts(List<BankAccount> accounts)
        {
            foreach (var account in Accounts)
            {
                Console.WriteLine($"Account: {account.Name}, Balance: {account.Balance}");
            }
        }
    }
}
