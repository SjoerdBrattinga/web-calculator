using System.ComponentModel.DataAnnotations;

namespace WebCalculator;

public class CalculationRequest
{
    [Required(ErrorMessage = "Operand 1 is required")]
    public decimal? Operand1 { get; set; }

    [Required(ErrorMessage = "Operand 2 is required")]
    public decimal? Operand2 { get; set; }

    [Required(ErrorMessage = "Operator is required")]
    [RegularExpression("[+\\-*/]", ErrorMessage = "Invalid operator")]
    public string? Operator { get; set; }
}

