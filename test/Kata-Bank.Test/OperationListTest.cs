using System;
using Kata_Bank.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata_Bank.Test
{
    [TestClass]
    public class OperationListTest
    {
        [TestMethod]
        public void OperationListCreation()
        {
            OperationList operations = new OperationList();

            Assert.IsNotNull(operations);
        }

        [TestMethod]
        public void AddOperation()
        {
            OperationList operations = new OperationList();

            var deposit = new Deposit(33.56, DateTime.Now);

            var allOperations = operations.Add(deposit);

            Assert.AreEqual(1, allOperations.Count);
        }
        
        [TestMethod]
        public void ComputeBalance()
        {
            OperationList operations = new OperationList();

            var deposit = new Deposit(21.01, DateTime.Now);

            operations.Add(deposit);

            var balance = operations.ComputeBalance();

            Assert.AreEqual(21.01, balance);
        }
    }
}