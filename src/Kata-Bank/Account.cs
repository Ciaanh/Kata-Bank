using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kata_Bank.Operations;

namespace Kata_Bank
{
    public class Account : IEquatable<Account>
    {
        private readonly Guid _accountIdentificator;
        private OperationList _operations = new OperationList();

        public Account(Guid accountIdentificator)
        {
            _accountIdentificator = accountIdentificator;
        }

        public double MakeDeposit(double amount, DateTime date)
        {
            Operation operation = new Deposit(amount, date);
            _operations.Add(operation);
            return _operations.ComputeBalance();
        }

        public double MakeWithdrawal(double amount, DateTime date)
        {
            Operation operation = new Withdrawal(amount, date);
            _operations.Add(operation);
            return _operations.ComputeBalance();
        }

        public Func<Guid, bool> IdentifyAccount()
        {
            return givenGuid => _accountIdentificator == givenGuid;
        }

        public double AccountBalance()
        {
            return _operations.ComputeBalance();

        }

        #region IEquatable
        public override int GetHashCode()
        {
            return _accountIdentificator.GetHashCode();
        }

        public override bool Equals(object otherAccount)
        {
            return otherAccount is Account && Equals((Account)otherAccount);
        }

        public bool Equals(Account otherAccount)
        {
            return _accountIdentificator == otherAccount._accountIdentificator;
        }
        #endregion
    }
}
