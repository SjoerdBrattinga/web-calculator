using WebCalculator.Domain.Models;

namespace WebCalculator.Models;

public class CalculatorResponse
{
    // TODO: implement this as the API response.
    // Fluent validation can have multiple validation errors
    // so list with errorMessages should be returned.
    // CalculatorResponse should be mapped from CalculatorResult

    public bool IsSuccess { get; set; }
    public OperationResult Calculation { get; set; }
    public List<string> ErrorMessages { get; set; }

    public CalculatorResponse()
    {
        IsSuccess = false;
        ErrorMessages = new List<string>();
    }
}
