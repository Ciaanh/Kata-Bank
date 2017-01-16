using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata_Bank.Operations
{
    public class Deposit : Operation
    {
        public Deposit(double amount, DateTime date) : base(amount, date)
        {
        }

        public override double ComputeOperation(double previousBalance)
        {
            return previousBalance + _amount;
        }
    }
}
