namespace WebCalculator.Domain.Models;

public class OperationResult
{
    public bool IsSuccess { get; set; }
    public double? Result { get; set; }
    public string? Operation { get; set; }
    public string? ErrorMessage { get; set; }

    public static OperationResult Success(double result, string operation)
    {
        return new OperationResult
        {
            IsSuccess = true,
            Result = result,
            Operation = operation
        };
    }

    public static OperationResult Failure(string errorMessage, string operation)
    {
        return new OperationResult
        {
            IsSuccess = false,
            ErrorMessage = errorMessage,
            Operation = operation
        };
    }
}
