using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Interfaces;

public interface IOperation
{   
    string OperatorType { get; }
    int Precedence { get; }

    OperationResult Calculate();
}

