using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kata_Bank.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata_Bank.Test
{
    [TestClass]
    public class OperationTest
    {
        [TestMethod]
        public void DepositCreation()
        {
            Operation operation1 = new Deposit(0, DateTime.Now);

            Assert.IsNotNull(operation1);
        }

        [TestMethod]
        public void ComputeDeposit()
        {
            Operation operation1 = new Deposit(33, DateTime.Now);

            var balance = operation1.ComputeOperation(-1.5);

            Assert.AreEqual(31.5, balance);
        }

        [TestMethod]
        public void WithdrawalCreation()
        {
            Operation operation1 = new Withdrawal(0, DateTime.Now);

            Assert.IsNotNull(operation1);
        }

        [TestMethod]
        public void ComputeWithdrawal()
        {
            Operation operation1 = new Withdrawal(33, DateTime.Now);

            var balance = operation1.ComputeOperation(1.5);

            Assert.AreEqual(-31.5, balance);
        }
    }
}
