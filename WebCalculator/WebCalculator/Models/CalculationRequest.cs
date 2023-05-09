using System.ComponentModel.DataAnnotations;

namespace WebCalculator.Models;

public class CalculationRequest
{
    [Required(ErrorMessage = "Operand is required")]
    public double Operand1 { get; set; }

    //[Required(ErrorMessage = "Operand 2 is required")]
    public double? Operand2 { get; set; }

    [Required(ErrorMessage = "Operator is required")]
    public string Operator { get; set; }
}

