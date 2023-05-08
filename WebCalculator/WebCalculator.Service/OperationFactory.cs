using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Domain.Operations;

namespace WebCalculator.Service;

public class OperationFactory : IOperationFactory
{
    private readonly Func<IEnumerable<IOperation>> _factory;

    public OperationFactory(Func<IEnumerable<IOperation>> factory)
    {
        _factory = factory;
    }
    public IOperation Create(string operatorType)
    {
        //TODO: validate input
        var set = _factory();
        IOperation operation = set.Where(x => x.OperatorType == operatorType.ToLower()).First();

        return operation;
    }
}
