using WebCalculator.Domain;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Domain.Operations;

namespace WebCalculator.Application;

public class CalculatorService : ICalculatorService
{
    private readonly IOperationFactory _operationFactory;

    public CalculatorService(IOperationFactory operationFactory)
    {
        _operationFactory = operationFactory;
    }

    public CalculatorResult PerformOperation(Calculation calculation)
    {
        try
        {
            IOperation operation = _operationFactory.CreateWithValues(calculation.Operator, calculation.Operand1, calculation.Operand2);

            OperationResult result = operation.Calculate();

            if (result.Result.HasValue)
            {
                if (IsCloseToInteger(result.Result.Value))
                {
                    result.Result = Math.Round(result.Result.Value);
                }
            }

            return new CalculatorResult(result);
        }
        catch (Exception ex)
        {
            //TODO: Log exceptions
            return CalculatorResult.Failure(ex.Message);
        }
    }

    private bool IsCloseToInteger(double value)
    {
        // Round numbers like: 0.0000000004 
        const double epsilon = 1e-10;
        var rounded = Math.Round(value);

        return Math.Abs(value - rounded) < epsilon;
    }




    // Not implemented, work in progres... 
    public CalculatorResult CalculateExpression(List<double> values, List<string> @operator)
    {
        List<IOperation> operations = new();

        foreach (var op in @operator)
        {
            if (Constants.SupportedOperators.Contains(op))
            {
                IOperation operation = _operationFactory.Create(op);
                if (operation != null)
                {
                    operations.Add(operation);
                }
            }
            else
            {
                throw new ArgumentException($"Unknown operation '{op}'.");
            }
        }
        while (operations.Count > 0)
        {
            var operation = operations.OrderByDescending(op => op.Precedence).First();
            int index = operations.IndexOf(operation);

            // Check if a value was found
            if (index >= 0)
            {
                double result = 0;
                OperationResult? operationResult = null;

                // Calculate the result of the operation and replace the values in the list
                if (operation is UnaryOperation unary)
                {
                    unary.Operand = values[index];
                    operationResult = unary.Calculate();
                    values.RemoveAt(index);
                }
                else if (operation is BinaryOperation binary)
                {
                    binary.Operand1 = values[index];
                    binary.Operand2 = values[index + 1];
                    operationResult = binary.Calculate();
                    values.RemoveRange(index, 2);
                }
                if (operationResult != null && operationResult.IsSuccess && operationResult.Result.HasValue)
                {
                    result = operationResult.Result.Value;
                }
                else
                {
                    // return CalculatorResult.Failure(operationResult.ErrorMessage);
                }

                operations.RemoveAt(index);
                values.Insert(index, result);
            }
        }

        // Return the final result, which should be the only value left in the values list
        // return values[0];

        return CalculatorResult.Failure("Not implemented");
    }
}