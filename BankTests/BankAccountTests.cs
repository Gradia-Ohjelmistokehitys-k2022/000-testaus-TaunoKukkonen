
using BankAccountNS;
namespace BankTests

{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {

            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankCustomer timo = new BankCustomer("Timo");
            timo.NewAccount(beginningBalance, 1);

            timo.Accounts[0].Debit(debitAmount);


            double actual = timo.Accounts[0].Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {

            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankCustomer timo = new BankCustomer("Timo");
            timo.NewAccount(beginningBalance, 1);


            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => timo.Accounts[0].Debit(debitAmount));
        }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {

            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankCustomer timo = new BankCustomer("Timo");
            timo.NewAccount(beginningBalance, 1);


            try
            {
                timo.Accounts[0].Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {

                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        [TestMethod]
        public void NewAccount_WithValidAmount_CreatesNewAccount()
        {

            double beginningBalance = 11.99;
            int id = 123;
            BankCustomer customer = new BankCustomer("Timo");


            customer.NewAccount(beginningBalance, id);


            Assert.AreEqual(1, customer.Accounts.Count);
            Assert.AreEqual(beginningBalance, customer.Accounts[0].Balance);
            Assert.AreEqual(id, customer.Accounts[0]._id);
        }

        [TestMethod]
        public void RemoveAccount_WithValidId_RemovesAccount()
        {

            double beginningBalance = 11.99;
            int id = 123;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);


            customer.RemoveAccount(id);


            Assert.AreEqual(0, customer.Accounts.Count);
        }

        [TestMethod]
        public void RemoveAccount_WithInvalidId_ThrowsException()
        {

            double beginningBalance = 11.99;
            int id = 123;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);


            Assert.ThrowsException<System.InvalidOperationException>(() => customer.RemoveAccount(456));
        }
        [TestMethod]
        public void NewAccount_TwoAccountsSameID_ThrowsExeption()
        {
            double beginningBalance = 11.99;
            int id = 123;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);

            Assert.ThrowsException<Exception>(() => customer.NewAccount(beginningBalance, id));
        }
        [TestMethod]
        public void CustomerName_GetRightName_GivesName()
        {
            string name = "Timo";
            BankCustomer bankCustomer = new BankCustomer(name);
            Assert.AreEqual(name, bankCustomer.CustomerName);
        }
        [TestMethod]
        public void WithdrawDeposit_ValidAmounts_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            int id = 123;
            int id2 = 234;
            double expected = 1.99;
            double depositAmount = 10;
            double accountTwo = 0;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);
            customer.NewAccount(accountTwo, id2);

            double withdrawal = customer.Accounts[0].Withdraw(depositAmount);
            customer.Accounts[1].Deposit(withdrawal);
            double account1balance = customer.Accounts[0].Balance;
            double account2balance = customer.Accounts[1].Balance;
            double delta = 0.001;
            Console.WriteLine(account1balance.ToString(), account2balance.ToString());

            Assert.AreEqual(expected,account1balance, delta);
            Assert.AreEqual(depositAmount, account2balance, delta);
        }
        [TestMethod] 
        public void Withdraw_ValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double endBalance = 1.99;
            int id = 123;
            int withdrawn = 10;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);

            double expected = customer.Accounts[0].Withdraw(withdrawn);
            double gottenEndBalance = customer.Accounts[0].Balance;
            double delta = 0.001;

            Assert.AreEqual(expected, withdrawn, delta);
            Assert.AreEqual(endBalance, gottenEndBalance, delta);
        }
        [TestMethod]
        public void Deposti_ValidAmount_UpdatedBalance()
        {
            double beginningBalance = 11.99;
            double endBalance = 21.99;
            int id = 123;
            int deposited = 10;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);

            customer.Accounts[0].Deposit(deposited);
            double actual = customer.Accounts[0].Balance;
            double delta = 0.001;

            Assert.AreEqual(endBalance, actual, delta);
        }
        [TestMethod]
        public void NewAccoutn_TwoAcounts_NormallyCreated()
        {
            double beginningBalance = 11.99;
            int id = 123;
            int id2 = 234;
            double accountTwo = 0;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);
            customer.NewAccount(accountTwo, id2);
            int amountOfAcounts = customer.Accounts.Count;
            int expected = 2;
            Assert.AreEqual(expected, amountOfAcounts);
        }
        [TestMethod]
        public void Deposit_NegativeAmount_ThrowsExpection()
        {
            double beginningBalance = 11.99;
            double endBalance = 21.99;
            int id = 123;
            int deposited = -10;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customer.Accounts[0].Deposit(deposited));

        }
        [TestMethod]
        public void Withdraw_Overdraft_ThrowsExeption()
        {

            double beginningBalance = 11.99;
          
            int id = 123;
            int withdrawn = 100;
            BankCustomer customer = new BankCustomer("Timo");
            customer.NewAccount(beginningBalance, id);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => customer.Accounts[0].Withdraw(withdrawn));
        }
    }
}