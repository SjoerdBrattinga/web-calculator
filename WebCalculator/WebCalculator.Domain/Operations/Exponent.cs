using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations;

public class Exponent : IBinaryOperation
{
    public string OperatorType => "^";
    public int Precedence => 3;
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }    

    public double Calculate()
    {
        return Math.Pow(Operand1, Operand2);
    }

    public CalculatorResult Calculate(double operand1, double operand2)
    {
        double result = Math.Pow(operand1, operand2);

        return CalculatorResult.Success(result);
    }
}