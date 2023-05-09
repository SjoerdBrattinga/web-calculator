namespace WebCalculator.Domain.Interfaces;

public interface IOperationFactory
{
    IOperation Create(string operatorType);
}
