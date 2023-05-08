using System.Net;
using WebCalculator.Domain.Models;

namespace WebCalculator.Models;

public class CalculatorResponse
{
    public bool IsSuccess { get; set; } 
    public OperationResult Calculation { get; set; }
    public List<string> ErrorMessages { get; set; }

    public CalculatorResponse()
    {
        IsSuccess = false;
        ErrorMessages = new List<string>();
    }
}
