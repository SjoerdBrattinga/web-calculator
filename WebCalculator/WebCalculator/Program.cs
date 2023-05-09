using FluentValidation;
using System.Text.Json.Serialization;
using WebCalculator;
using WebCalculator.Domain.Interfaces;
using WebCalculator.Domain.Operations.Binary;
using WebCalculator.Domain.Operations.Unary;
using WebCalculator.Service;
using WebCalculator.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<CalculationRequestValidation>();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

builder.Services.AddTransient<IOperation, Addition>();
builder.Services.AddTransient<IOperation, Subtraction>();
builder.Services.AddTransient<IOperation, Multiplication>();
builder.Services.AddTransient<IOperation, Division>();
builder.Services.AddTransient<IOperation, Square>();
builder.Services.AddTransient<IOperation, SquareRoot>();
builder.Services.AddTransient<IOperation, Exponent>();
builder.Services.AddTransient<IOperation, Negate>();
builder.Services.AddSingleton<Func<IEnumerable<IOperation>>>
    (x => () => x.GetService<IEnumerable<IOperation>>()!);
builder.Services.AddSingleton<IOperationFactory, OperationFactory>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    /// Returns double.NaN and double.Infinity etc
    options.SerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureBasicApi();
app.ConfigureApi();

app.Run();

