using System;

namespace Kata_Bank.Operations
{
    public abstract class Operation
    {
        protected double _amount;
        protected DateTime _date;

        public Operation(double amount,DateTime date)
        {
            _amount = amount;
            _date = date;
        }

        public abstract double ComputeOperation(double previousBalance);
        
        public static Func<double, Operation, double> GetAggregationDelegate()
        {
            return (aggregate, nextValue) => nextValue.ComputeOperation(aggregate);
        }
    }
}