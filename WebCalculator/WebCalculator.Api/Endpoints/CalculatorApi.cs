using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebCalculator.Application;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Models;

namespace WebCalculator.Api.Endpoints;

public static class CalculatorApi
{    
    public static void ConfigureCalculatorApi(this WebApplication app)
    {
       // app.MapPost("/calculate", Calculate).Produces<CalculatorResult>(200).Produces(400);
        //app.MapGet("/api/perform-operation", PerformOperation).Produces<OperationResult>(200).Produces(400);
        app.MapPost("/api/perform-operation", PerformOperation).Produces<OperationResult>(200).Produces(400);
        //app.MapGet("api/calculate/{operand1}/{operator}/{operand2?}", PerformOperation).Produces<OperationResult>(200).Produces(400);
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

    private static IResult PerformOperation(CalculationRequest request, 
        IOperationFactory _operationFactory, IValidator<CalculationRequest> _validator)
        //double operand1, string @operator, double? operand2 = null)
    {
        
        try
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            IOperation operation = _operationFactory.CreateWithValues(request.Operator, request.Operand1, request.Operand2);

            if (operation is null)
            {
                Results.Problem("Invalid operation");
            }
            //operation.Calculate();
            return Results.Ok(operation.Calculate());

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
}


