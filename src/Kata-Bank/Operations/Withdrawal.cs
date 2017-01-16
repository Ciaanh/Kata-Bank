using System;

namespace Kata_Bank.Operations
{
    public class Withdrawal : Operation
    {
        public Withdrawal(double amount, DateTime date) : base(amount, date)
        {
        }

        public override double ComputeOperation(double previousBalance)
        {
            return previousBalance - _amount;
        }
    }
}