using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTest;
using Kata_Bank;
using Kata_Bank.Operations;

namespace Kata_Bank.Test
{
    [TestClass]
    public class AccountTest
    {

        [TestMethod]
        public void AccountCreation()
        {
            var accountId1 = new Guid("5b66eda3-1823-4117-92b1-77d8c37fabcf");

            Account account1 = new Account(accountId1);

            Assert.IsNotNull(account1);
        }

        [TestMethod]
        public void AccountEqualityComparison()
        {
            var accountId1 = new Guid("5b66eda3-1823-4117-92b1-77d8c37fabcf");

            var accountId2 = new Guid("476f25a9-952b-464e-b6b6-f15c6e42d95a");

            Account account1 = new Account(accountId1);
            Account account2 = new Account(accountId2);

            Assert.AreNotEqual(account2, account1);

            Assert.AreEqual(account1, account1);
        }

        [TestMethod]
        public void MakeDeposit()
        {
            var accountId1 = new Guid("5b66eda3-1823-4117-92b1-77d8c37fabcf");
            Account account1 = new Account(accountId1);


            account1.MakeDeposit(33.33, DateTime.Now);
            var balance = account1.AccountBalance();

            Assert.AreEqual(33.33, balance);
        }

        [TestMethod]
        public void MakeWithdrawal()
        {
            var accountId1 = new Guid("5b66eda3-1823-4117-92b1-77d8c37fabcf");
            Account account1 = new Account(accountId1);


            account1.MakeWithdrawal(15.15, DateTime.Now);
            var balance = account1.AccountBalance();

            Assert.AreEqual(-15.15, balance);
        }
    }
}
