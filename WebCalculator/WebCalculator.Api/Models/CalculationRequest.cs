using System.ComponentModel.DataAnnotations;

namespace WebCalculator.Models;

public class CalculationRequest
{
    public double Operand1 { get; set; }
    public double? Operand2 { get; set; }
    public string Operator { get; set; }
}

