using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Interfaces;

public interface IUnaryOperation : IOperation
{
    double Operand { get; set; }

    CalculatorResult Calculate(double operand);
}

