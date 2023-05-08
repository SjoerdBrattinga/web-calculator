using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations.Unary;

public class SquareRoot : UnaryOperation
{
    public override string OperatorType => "sqrt";
    public override int Precedence => 3;

    public override OperationResult Calculate()
    {
        double result = Math.Sqrt(Operand);

        if (Operand < 0)
        {
            return OperationResult.Failure("Cannot calculate square root of a negative number.", ToString());
        }

        return OperationResult.Success(result, ToString());
    }
}

