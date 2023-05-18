namespace WebCalculator.Domain.Models;

public class CalculatorResult
{
    public bool IsSuccess { get; set; }
    public OperationResult? Operation { get; set; }
    public string? ErrorMessage { get; set; }

    private CalculatorResult() { }
    public CalculatorResult(OperationResult result)
    {

        IsSuccess = result.IsSuccess;
        Operation = result;
        ErrorMessage = result.IsSuccess ? null : result.ErrorMessage;

    }

    public static CalculatorResult Failure(string errorMessage)
    {
        return new CalculatorResult
        {
            IsSuccess = false,
            ErrorMessage = errorMessage
        };
    }
}
