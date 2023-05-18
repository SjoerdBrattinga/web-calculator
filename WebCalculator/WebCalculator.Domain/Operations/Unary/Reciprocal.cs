using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations.Unary;
public class Reciprocal : UnaryOperation
{
    public override string OperatorType => "1/";

    public override int Precedence => 3;

    public override OperationResult Calculate()
    {
        double result = 1 / Operand;

        if (Operand == 0)
        {
            return OperationResult.Failure("Cannot divide by zero.", ToString());
        }

        return OperationResult.Success(result, ToString());
    }
}
