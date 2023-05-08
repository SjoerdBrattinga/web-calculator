using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations;

public class Square : IUnaryOperation
{
    public string OperatorType => "sqr";
    public int Precedence => 3;
    public double Operand { get; set; }    

    public double Calculate()
    {
        return Math.Pow(Operand, 2);
    }

    public CalculatorResult Calculate(double operand)
    {        
        double result = Math.Pow(Operand, 2);

        return CalculatorResult.Success(result);   
    }

}