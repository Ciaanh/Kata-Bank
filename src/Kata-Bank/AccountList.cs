using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata_Bank
{
    public class AccountList
    {
        private HashSet<Account> _accounts= new HashSet<Account>();

       public void Register(Account account)
        {
            if (_accounts.Contains(account))
            {
                return;
            }
            _accounts.Add(account);
        }

        public Account Find(Guid accountId)
        {
            Account result = _accounts.SingleOrDefault(account =>
            {
                var identificator = account.IdentifyAccount();
                return identificator(accountId);
            });

            return result;
        }

        public void MakeTransfer(double amount, Guid fromAccountIdentificator, Guid toAccountIdentificator, DateTime date)
        {
            var fromAccount = Find(fromAccountIdentificator);
            var toAccount = Find(toAccountIdentificator);

            fromAccount.MakeWithdrawal(amount, date);
            toAccount.MakeDeposit(amount, date);
        }
    }
}