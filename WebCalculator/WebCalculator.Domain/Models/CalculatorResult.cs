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
    public double? Result { get; set; }    
    public string? ErrorMessage { get; set; }

    public static CalculatorResult Success(double result)
    {
        return new CalculatorResult
        {
            IsSuccess = true,
            Result = result
        };              
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
