using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebCalculator;

public static class Api
{
    public record ErrorResponse(int StatusCode, string Message);

    public static void ConfigureApi(this WebApplication app)
    {

        app.MapGet("/add/{a}/{b}", (double a, double b) => a + b).Produces<double>().ProducesBadRequest();
        app.MapGet("/subtract/{a}/{b}", (double a, double b) => a - b).Produces<double>().ProducesBadRequest();
        app.MapGet("/multiply/{a}/{b}", (double a, double b) => a * b).Produces<double>().ProducesBadRequest();
        app.MapGet("/divide/{a}/{b}", (double a, double b) => b == 0 ? throw new InvalidOperationException("Cannot divide by zero") : a / b).Produces<double>().ProducesBadRequest();
        app.MapGet("/negate/{a}", (double a) => -a).Produces<double>().ProducesBadRequest();

        app.MapPost("/calculate", Calculate);
    }

    private static IResult Calculate([FromBody] CalculationRequest calculation)
    {
        try
        {
            var result = calculation.Operator switch
            {
                "+" => calculation.Operand1 + calculation.Operand2,
                "-" => calculation.Operand1 - calculation.Operand2,
                "*" => calculation.Operand1 * calculation.Operand2,
                "/" => calculation.Operand2 != 0 ? calculation.Operand1 / calculation.Operand2 : throw new ArgumentException("Cannot divide by zero"),
                _ => throw new ArgumentException($"Invalid operator '{calculation.Operator}'")
            };

            if (!result.HasValue)
            {                
                return Results.Problem("Invalid result");                    
            }
            
            return Results.Ok(new CalculationResult { Result = result.Value});                           

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);            
         
        }
    }
}
   

