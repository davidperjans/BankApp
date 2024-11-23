using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Classes.BankAccounts
{
    public class BankAccount
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }

        public BankAccount(string name, string accountNumber, decimal balance)
        {
            Name = name;
            AccountNumber = accountNumber;
            Balance = balance;
            CreatedDate = DateTime.Now;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            //Transactions.Add(new Transaction { Amount = amount, Type = "Deposit" });
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
            //Transactions.Add(new Transaction { Amount = amount, Type = "Withdrawal" });
        }
    }
}
