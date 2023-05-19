using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Operations;

namespace WebCalculator.Application;

public class OperationFactory : IOperationFactory
{
    // Using a factory pattern because there is 1 endpoint that accepts unary and binary operators. This pattern allows to easily add new features to the calculator.

    private readonly Func<IEnumerable<IOperation>> _factory;

    public OperationFactory(Func<IEnumerable<IOperation>> factory)
    {
        _factory = factory;
    }

    public IOperation Create(string operatorType)
    {
        // Retrieve the set of operations from the factory function
        var set = _factory();

        // Find the operation with the matching operator type
        IOperation operation = set.Where(x => x.OperatorType == operatorType.ToLower()).First();

        return operation;
    }

    public IOperation CreateWithValues(string operatorType, double operand1, double? operand2)
    {
        // Create the operation using the Create method
        IOperation operation = Create(operatorType);

        // Set the operands based on the operation type
        if (operation is UnaryOperation unary)
        {
            unary.Operand = operand1;
        }
        else if (operation is BinaryOperation binary && operand2.HasValue)
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
