using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Interfaces;

public interface ICalculatorService
{
    CalculatorResult CalculateExpression(List<double> values, List<string> @operator);
    CalculatorResult PerformOperation(Calculation operation);
}