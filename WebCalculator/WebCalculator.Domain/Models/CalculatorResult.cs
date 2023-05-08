using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Domain.Interfaces;

namespace WebCalculator.Domain.Models;

public class CalculatorResult
{
    public bool IsSuccess { get; set; }
    public OperationResult? Result { get; set; }    
    public string? ErrorMessage { get; set; }

    private CalculatorResult() { }
    public CalculatorResult(OperationResult result)
    {

        IsSuccess = result.IsSuccess;
        Result = result;
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
