using FluentValidation;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Models;
using WebCalculator.Models;

namespace WebCalculator.Api.Endpoints;

public static class CalculatorApi
{
    public static void ConfigureCalculatorApi(this WebApplication app)
    {
        app.MapPost("/api/perform-operation", PerformOperation).Produces<OperationResult>(200).Produces(400);
    }

    // TODO: use CalculatorResponse as return type so the client always get the same response type
    private static IResult PerformOperation(CalculationRequest request,
        ICalculatorService calculator, IValidator<CalculationRequest> _validator)
    {
        try
        {
            // Validate the calculation request using fluent validation
            // You cant use !modelstate.isvalid in minimal api
            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            // Create a new Calculation object with the properties from the request
            // TODO: use automapper
            var calculatorResult = calculator.PerformOperation(new Calculation()
            {
                Operator = request.Operator,
                Operand1 = request.Operand1,
                Operand2 = request.Operand2.Value
            });

            // Return an OK result with the operation 
            // Operation can be insuccesful and have an errorMessage like: Cannot divide by zero
            return Results.Ok(calculatorResult.Operation);
        }
        catch (ArgumentException ex)
        {
            // If an ArgumentException occurs during the calculation, return a bad request result
            // with the exception message
            return Results.BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // If any other exception occurs during the calculation, return a problem result
            // with the exception message
            return Results.Problem(ex.Message);
        }
    }
}


