using System.ComponentModel.DataAnnotations;

namespace WebCalculator.Domain.Models;

public class Calculation
{
    //public int? Id { get; set; }

    public double? Operand1 { get; set; }

    public double? Operand2 { get; set; }

    public string? Operator { get; set; }

    public double? Result { get; set; }
}
