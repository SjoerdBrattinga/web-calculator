using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations;

public abstract class UnaryOperation : IOperation
{
    public double Operand { get; set; }


    public abstract string OperatorType { get; }
    public abstract int Precedence { get; }

    public abstract OperationResult Calculate();

    public override string ToString()
    {
        return $"{OperatorType}({Operand})";
    }
}

