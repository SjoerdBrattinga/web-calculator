namespace WebCalculator.Api.Endpoints;

public static class BasicCalculatorApi
{
    // Basic operations, not used in web app.
    public static void ConfigureBasicCalculatorApi(this WebApplication app)
    {
        app.MapGet("/api/add/{number1}/{number2}", (double number1, double number2) => number1 + number2).Produces<double>().Produces(400);
        app.MapGet("/api/subtract/{number1}/{number2}", (double number1, double number2) => number1 - number2).Produces<double>().Produces(400);
        app.MapGet("/api/multiply/{number1}/{number2}", (double number1, double number2) => number1 * number2).Produces<double>().Produces(400);
        app.MapGet("/api/divide/{number1}/{number2}", (double number1, double number2) => number1 / number2).Produces<double>().Produces(400);
        app.MapGet("/api/negate/{number}", (double number) => -number).Produces<double>().Produces(400);
        app.MapGet("/api/sqrt/{number}", (double number) => Math.Sqrt(number)).Produces<double>().Produces(400);
        app.MapGet("/api/pow/{number1}/{number2}", (double number1, double number2) => Math.Pow(number1, number2)).Produces<double>().Produces(400);
    }
}


