using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Domain.Operations;

namespace WebCalculator.Service
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IOperationFactory _operationFactory;

        public CalculatorService(IOperationFactory operationFactory)
        {
            _operationFactory = operationFactory;
        }

        public CalculatorResult Calculate(Calculation calculation)
        {
            double result = 0;
            try
            {
                var operation = _operationFactory.Create(calculation.Operator);
                

                if (operation is IBinaryOperation)
                {

                }
                else if (operation is IUnaryOperation) 
                {

                }

                //result.Result = operation.Calculate();
                //result.Operation = operation;

                return CalculatorResult.Success(result);
            }
            catch (Exception ex)
            {                
                return CalculatorResult.Failure(ex.Message);
            }

            //CalculatorResult result = new()
            //{
            //    IsSuccess = true
            //};          

            //try
            //{
            //    var operation = OperationFactory.CreateOperation(calculation);

            //    result.Result = operation.Calculate();
            //    result.Operation = operation;

            //    return result;
            //}
            //catch (Exception ex)
            //{
            //    result.IsSuccess = false;
            //    result.ErrorMessage = ex.Message;

            //    return result;
            //}            
        }

  

            //public Calculation PerformCalculation(Calculation calculation)
            //{
            //    if (calculation is null)
            //    {
            //        throw new ArgumentNullException(nameof(calculation));
            //    }

            //    if(calculation.Operand2.HasValue)
            //    {
            //        calculation.Result = calculation.Operator switch
            //        {
            //            "+" => (double)(calculation.Operand1 + calculation.Operand2.Value),
            //            "-" => (double)(calculation.Operand1 - calculation.Operand2.Value),
            //            "*" => (double)(calculation.Operand1 * calculation.Operand2.Value),
            //            "/" => (double)(calculation.Operand1 / calculation.Operand2.Value),
            //            "%" => Percentage(calculation.Operand1, calculation.Operand2.Value),
            //            "^" => Power(calculation.Operand1, calculation.Operand2.Value),
            //            _ => null
            //        }; 
            //    }
            //    else
            //    {
            //        calculation.Result = calculation.Operator switch
            //        {
            //            "+-" => Negate(calculation.Operand1),
            //            "sqr" => Square(calculation.Operand1),
            //            "sqr_r" => SquareRoot(calculation.Operand1),
            //            _ => null
            //        };

            //    }

            //    return calculation;
            //}

            //private IOperation GetOperation(string operatorType)
            //{
            //    switch (operatorType)
            //    {
            //        case "+":
            //            return new Addition();
            //        case "-":
            //            return new SubtractionOperation();
            //        case "*":
            //            return new MultiplicationOperation();
            //        case "/":
            //            return new DivisionOperation();
            //        case "sqrt":
            //            return new SquareRootOperation();
            //        default:
            //            return null;
            //    }
            //}


            //public OperationType GetOperationType(string @operator)
            //{
            //    return @operator switch
            //    {
            //        "+" => OperationType.Addition,
            //        "-" => OperationType.Substaction,
            //        "*" => OperationType.Multiplication,
            //        "/" => OperationType.Division,
            //        "sqr" => OperationType.Square,
            //        "sqr_r" => OperationType.SquareRoot,
            //        "%" => OperationType.Percentage,
            //        "^" => OperationType.Exponent,
            //        _ => OperationType.Invalid,
            //    };
            //}


   

    }
}