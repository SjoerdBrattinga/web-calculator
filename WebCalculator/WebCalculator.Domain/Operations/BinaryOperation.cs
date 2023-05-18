using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations;

public abstract class BinaryOperation : IOperation
{
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }


    public abstract string OperatorType { get; }

    public abstract int Precedence { get; }

    public abstract OperationResult Calculate();

    public override string ToString()
    {
        return $"{Operand1} {OperatorType} {Operand2} ";
    }
}