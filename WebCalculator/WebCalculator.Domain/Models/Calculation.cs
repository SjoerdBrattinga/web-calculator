namespace WebCalculator.Domain.Models;

public class Calculation
{
    public double Operand1 { get; set; }

    public double? Operand2 { get; set; }

    public string Operator { get; set; } = string.Empty;
}
