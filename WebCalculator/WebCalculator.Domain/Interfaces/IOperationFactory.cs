namespace WebCalculator.Domain.Interfaces;

public interface IOperationFactory
{
    IOperation Create(string operatorType);
    IOperation CreateWithValues(string operatorType, double operand1, double? operand2);
}
