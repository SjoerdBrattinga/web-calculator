using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Domain.Operations;

namespace WebCalculator.Service;

public class OperationFactory : IOperationFactory
{
    private readonly Func<IEnumerable<IOperation>> _factory;

    public OperationFactory(Func<IEnumerable<IOperation>> factory)
    {
        _factory = factory;
    }
    public IOperation Create(string operatorType)
    {
        var set = _factory();
        IOperation operation = set.Where(x => x.OperatorType == operatorType.ToLower()).First();
        return operation;
    }
    //public static IOperation CreateOperation(Calculation calculation)
    //{  
    //    if (!calculation.Operand2.HasValue)
    //    {
    //        return CreateUnaryOperation(calculation.Operand1, calculation.Operator);
    //    }
    //    else
    //    {
    //        return CreateBinaryOperation(calculation.Operand1, calculation.Operand2.Value, calculation.Operator);
    //    }
    //}

    //public static IOperation GetOperation(string operatorType)
    //{
    //    return operatorType.ToLower() switch
    //    {
    //        "+" => new Addition(),
    //        "-" => new Subtraction(),
    //        "*" => new Multiplication(),
    //        "/" => new Division(),
    //        "^" => new Exponent(),
    //        "sqr" => new Square(),
    //        "sqrt" => new SquareRoot(),
    //        //"+-" => new Negate(),
    //        _ => throw new ArgumentException("Invalid operator type"),
    //    };
    //}

    //private static IUnaryOperation CreateUnaryOperation(double operand, string operatorType)
    //{
    //    return operatorType.ToLower() switch
    //    {
    //        "sqr"  => new Square { Operand = operand },
    //        "sqrt" => new SquareRoot { Operand = operand },
    //        //"+-"   => new Negate { Operand = operand },
    //        _ => throw new ArgumentException("Invalid operator type"),
    //    };
    //}

    //private static IOperation CreateBinaryOperation(double operand1, double operand2, string operatorType)
    //{
    //    return operatorType.ToLower() switch
    //    {
    //        "+" => new Addition { Operand1 = operand1, Operand2 = operand2 },
    //        "-" => new Subtraction { Operand1 = operand1, Operand2 = operand2 },
    //        "*" => new Multiplication { Operand1 = operand1, Operand2 = operand2 },
    //        "/" => new Division { Operand1 = operand1, Operand2 = operand2 },
    //        "^" => new Exponent { Operand1 = operand1, Operand2 = operand2 },
    //        _ => throw new ArgumentException("Invalid operator type"),
    //    };
    //}

}
