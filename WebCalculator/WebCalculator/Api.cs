﻿using FluentValidation;
using WebCalculator.Domain;
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
        if (string.IsNullOrEmpty(@operator))
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
}


