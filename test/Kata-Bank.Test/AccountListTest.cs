using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata_Bank.Test
{
    [TestClass]
    public class AccountListTest
    {
        [TestMethod]
        public void AccountListCreation()
        {
            AccountList allAccounts = new AccountList();

            Assert.IsNotNull(allAccounts);
        }

        [TestMethod]
        public void RegisterFindTest()
        {
            AccountList allAccounts = new AccountList();

            var accountId1 = new Guid("5b66eda3-1823-4117-92b1-77d8c37fabcf");
            var accountId2 = new Guid("476f25a9-952b-464e-b6b6-f15c6e42d95a");

            Account account1 = new Account(accountId1);
            Account account2 = new Account(accountId2);

            allAccounts.Register(account1);
            allAccounts.Register(account2);

            var foundAccount1 = allAccounts.Find(accountId1);

            Assert.AreEqual(account1, foundAccount1);


            allAccounts.Register(account2);

            var foundAccount2 = allAccounts.Find(accountId2);
            Assert.AreNotEqual(account1, foundAccount2);
        }

        [TestMethod]
        public void TransferBetweenAccount()
        {
            var accountId1 = new Guid("5b66eda3-1823-4117-92b1-77d8c37fabcf");
            var accountId2 = new Guid("476f25a9-952b-464e-b6b6-f15c6e42d95a");
            var accountId3 = new Guid("936e8c98-25f7-4217-93c0-c5ee69179f5f");

            Account account1 = new Account(accountId1);
            Account account2 = new Account(accountId2);
            Account account3 = new Account(accountId3);

            AccountList allAccounts = new AccountList();

            var today = DateTime.Today;

            account1.MakeDeposit(100, today);
            account2.MakeDeposit(250, today);
            account3.MakeDeposit(75, today);

            allAccounts.Register(account1);
            allAccounts.Register(account2);
            allAccounts.Register(account3);

            allAccounts.MakeTransfer(72.5, accountId2, accountId1, today.AddDays(1));

            Assert.AreEqual(177.5, account2.AccountBalance());
            Assert.AreEqual(172.5, account1.AccountBalance());
            Assert.AreEqual(75, account3.AccountBalance());
        }
    }
}