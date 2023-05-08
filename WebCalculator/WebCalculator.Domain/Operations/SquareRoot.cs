using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations;

public class SquareRoot : IUnaryOperation
{
    public string OperatorType => "sqrt";
    public int Precedence => 3;
    public double Operand { get; set; }

    public double Calculate()
    {
        return Math.Sqrt(Operand);
    }

    public CalculatorResult Calculate(double operand)
    {
        double result = Math.Sqrt(operand);

        if (operand < 0)
        {
            return CalculatorResult.Failure("Cannot calculate square root of a negative number.");          
        }        

        return CalculatorResult.Success(result);
    }
}

