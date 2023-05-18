using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Interfaces;

public interface ICalculatorService
{
    CalculatorResult Calculate(Calculation operation);
    CalculatorResult PerformOperation(Calculation operation);
}