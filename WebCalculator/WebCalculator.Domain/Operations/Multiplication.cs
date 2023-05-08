﻿using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;

namespace WebCalculator.Domain.Operations;

public class Multiplication : IBinaryOperation
{
    public string OperatorType => "*";
    public int Precedence => 2;
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }
    

    public double Calculate()
    {
        return Operand1 * Operand2;
    }

    public CalculatorResult Calculate(double operand1, double operand2)
    {
        double result = operand1 * operand2;

        return CalculatorResult.Success(result);
    }
}