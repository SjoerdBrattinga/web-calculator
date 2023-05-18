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

    public CalculatorResult Calculate(Calculation calculation)
    {
        try
        {
            if (string.IsNullOrEmpty(calculation.Operator))
            {
                return CalculatorResult.Failure("Operator is required");
            }

            //var operation = _operationFactory.Create(calculation.Operator);

            //if (operation == null)
            //{
            //    return CalculatorResult.Failure("Invalid operation");
            //}

            //if (operation is BinaryOperation binaryOperation &&
            //    calculation.Operand1.HasValue && calculation.Operand2.HasValue)
            //{
            //    binaryOperation.Operand1 = calculation.Operand1.Value;
            //    binaryOperation.Operand2 = calculation.Operand2.Value;
            //}
            //else if (operation is UnaryOperation unaryOperation
            //    && calculation.Operand1.HasValue)
            //{
            //    unaryOperation.Operand = calculation.Operand1.Value;
            //}


            //OperationResult result = operation.Calculate();

            //return new CalculatorResult(result);
            return CalculatorResult.Failure("");

        }
        catch (Exception ex)
        {
            return CalculatorResult.Failure(ex.Message);
        }
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
            return CalculatorResult.Failure(ex.Message);
        }
    }

    private bool IsCloseToInteger(double value)
    {
        const double epsilon = 1e-10; // Adjust the epsilon value as needed

        var rounded = Math.Round(value);
        return Math.Abs(value - rounded) < epsilon;
    }
}