using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Interfaces;

public interface IBinaryOperation : IOperation
{
    double Operand1 { get; set; }
    double Operand2 { get; set; }
    CalculatorResult Calculate(double operand1, double operand2);
}

