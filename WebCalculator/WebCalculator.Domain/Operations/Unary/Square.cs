using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations.Unary;

public class Square : UnaryOperation
{
    public override string OperatorType => "sqr";
    public override int Precedence => 3;

    public override OperationResult Calculate()
    {
        double result = Math.Pow(Operand, 2);

        return OperationResult.Success(result, ToString());
    }
}