using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Models;

namespace WebCalculator;

public static class Api
{
    public static void ConfigureBasicApi(this WebApplication app)
    {

        app.MapGet("/add/{number1}/{number2}", (double a, double b) => a + b).Produces<double>().Produces(400);
        app.MapGet("/subtract/{number1}/{number2}", (double a, double b) => a - b).Produces<double>().Produces(400);
        app.MapGet("/multiply/{number1}/{number2}", (double a, double b) => a * b).Produces<double>().Produces(400);
        app.MapGet("/divide/{number1}/{number2}", (double a, double b) => a / b).Produces<double>().Produces(400);  
        app.MapGet("/negate/{number}", (double a) => -a).Produces<double>().Produces(400);
        app.MapGet("/sqrt/{number}", (double a) => Math.Sqrt(a)).Produces<double>().Produces(400); 
        app.MapGet("/pow/{base}/{exponent}", (double a, double b) => Math.Pow(a, b)).Produces<double>().Produces(400);
    }

    public static void ConfigureApi(this WebApplication app)
    {
        app.MapPost("/calculate", Calculate).Produces<IResult>().Produces(400);
        app.MapGet("/calculate", Calculate2).Produces<IResult>().Produces(400);
        app.MapGet("/calculate/{operand1}/{operator}/{operand2?}", Calculate2).Produces<IResult>().Produces(400);
    }

    private static IResult Calculate(CalculationRequest request, IValidator<CalculationRequest> _validator, ICalculatorService calculator)
    {    
        try
        {  
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {                
                return Results.ValidationProblem(validationResult.ToDictionary());
            }   


            var calculationResult = calculator.Calculate(new Calculation()
            {
                Operator = request.Operator,
                Operand1 = request.Operand1,
                Operand2 = request.Operand2.Value
            });


            return Results.Ok(calculationResult);

        }
        catch (DivideByZeroException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            //return calculationResult;
            return Results.Problem(ex.Message);

        }
    }

    private static IResult Calculate2(ICalculatorService calculator, double operand1, string @operator, double? operand2 = null)
    {
        if(string.IsNullOrEmpty(@operator))
        {
            return Results.BadRequest("Operator is required");
        }
        try
        {
           
            var calculationResult = calculator.Calculate(new Calculation()
            {
                Operator = @operator,
                Operand1 = operand1,
                Operand2 = operand2
            });


            return Results.Ok(calculationResult);

        }
        catch (DivideByZeroException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            //return calculationResult;
            return Results.Problem(ex.Message);

        }
    }
    //private static CalculatorResponse Addition(double a, double b, ICalculator calculator)
    //{
    //    CalculatorResponse response = new();
    //    var result = calculator.Add(a, b);
    //    if(result.iss)
    //    result.StatusCode = System.Net.HttpStatusCode.OK; 
    //    return result;
    //}

    //private static IResult Calculate([FromBody] CalculationRequest calculationRequest, IValidator<CalculationRequest> _validator)
    //{   
    //    try
    //    {
    //        CalculatorResponse calculationResult = new();
    //        var validationResult = _validator.Validate(calculationRequest);

    //        if (!validationResult.IsValid)
    //        {
    //            return Results.ValidationProblem(validationResult.ToDictionary());
    //        }


    //        Calculation calculation = new()
    //        {
    //            Operator = calculationRequest.Operator,
    //            Operand1 = calculationRequest.Operand1.Value,
    //            Operand2 = calculationRequest.Operand2.Value
    //        };



    //        calculationResult.Result = Calculator.Calculate(calculation);


    //        return Results.Ok(calculationResult.Result);                           

    //    }
    //    catch (DivideByZeroException ex)
    //    {
    //        return Results.BadRequest(ex.Message);
    //    }
    //    catch (ArgumentException ex)
    //    {
    //        return Results.BadRequest(ex.Message);
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);            

    //    }
    //}
}
   

