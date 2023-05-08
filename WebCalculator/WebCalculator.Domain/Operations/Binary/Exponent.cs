using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations.Binary;

public class Exponent : BinaryOperation
{
    public override string OperatorType => "^";
    public override int Precedence => 3;

    public override OperationResult Calculate()
    {
        double result = Math.Pow(Operand1, Operand2);

        return OperationResult.Success(result, ToString());
    }
}