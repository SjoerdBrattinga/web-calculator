using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations.Binary;

public class Division : BinaryOperation
{
    public override string OperatorType => "/";
    public override int Precedence => 2;

    public override OperationResult Calculate()
    {
        double result = Operand1 / Operand2;

        if (Operand2 == 0)
        {
            return OperationResult.Failure("Cannot divide by zero.", ToString());
        }

        return OperationResult.Success(result, ToString());
    }
}
