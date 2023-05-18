using FluentValidation;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Models;

namespace WebCalculator.Api.Endpoints;

public static class CalculatorApi
{
    public static void ConfigureCalculatorApi(this WebApplication app)
    {
        app.MapPost("/api/perform-operation", PerformOperation2).Produces<OperationResult>(200).Produces(400);
    }

    private static IResult PerformOperation2(CalculationRequest request,
        ICalculatorService calculator, IValidator<CalculationRequest> _validator)
    {
        try
        {
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var calculatorResult = calculator.PerformOperation(new Calculation()
            {
                Operator = request.Operator,
                Operand1 = request.Operand1,
                Operand2 = request.Operand2.Value
            });

            return Results.Ok(calculatorResult.Operation);
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}


