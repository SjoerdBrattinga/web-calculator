using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations.Binary;

public class Multiplication : BinaryOperation
{
    public override string OperatorType => "*"; 
    public override int Precedence => 2;

    public override OperationResult Calculate()
    {
        double result = Operand1 * Operand2;

        return OperationResult.Success(result, ToString());
    }
}
