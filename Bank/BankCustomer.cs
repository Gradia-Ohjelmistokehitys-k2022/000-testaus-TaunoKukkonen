using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BankAccountNS
{
    public class BankCustomer
    {
        private readonly string m_customerName;
        private List<BankAccount> bankAccounts;

        public BankCustomer(string name)
        {
            m_customerName = name;
            bankAccounts  = new List<BankAccount>();
        }
        public List<BankAccount> Accounts
        {
            get { return bankAccounts; }
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }
        public void NewAccount(double balance, int id)
        {
            if (bankAccounts.Any(account => account._id == id))
            {
                throw new Exception("Account with this ID already exists.");
            }

            BankAccount newAccount = new BankAccount(balance, id);
            bankAccounts.Add(newAccount);
        }
        public void RemoveAccount(int id)
        {

            BankAccount removedAccount = bankAccounts.FirstOrDefault(a => a._id == id);
            if (removedAccount != null) { bankAccounts.Remove(removedAccount); }
            else { throw new InvalidOperationException(); }
        }
       

    }
}
