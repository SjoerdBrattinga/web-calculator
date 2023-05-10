using System.Security.Cryptography.X509Certificates;
using WebCalculator.Domain;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Operations;

namespace WebCalculator.Application;

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

    public IOperation CreateWithValues(string operatorType, double operand1, double? operand2)
    {
        IOperation operation = Create(operatorType);

        if(operation is UnaryOperation unary)
        {
            unary.Operand = operand1;
        } 
        else if(operation is BinaryOperation binary && operand2.HasValue)
        {
            binary.Operand1 = operand1;
            binary.Operand2 = operand2.Value;
        }
        else
        {
            throw new InvalidOperationException("Could not create Operation with values.");
        }

        return operation;
    }
}
