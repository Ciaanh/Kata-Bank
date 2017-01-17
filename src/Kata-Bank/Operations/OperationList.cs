using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kata_Bank.Operations
{
    public class OperationList
    {
        private List<Operation> _operations = new List<Operation>();

        public List<Operation> Add(Operation operation)
        {
            _operations.Add(operation);
            return _operations;
        }

        public double ComputeBalance()
        {
            var aggregateFunction = Operation.GetAggregationDelegate();
            return _operations.Aggregate(0.0, aggregateFunction);
        }
    }
}
