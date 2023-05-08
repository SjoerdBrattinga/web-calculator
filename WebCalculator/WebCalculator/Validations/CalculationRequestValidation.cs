using FluentValidation;
using WebCalculator.Models;

namespace WebCalculator.Validations;

public class CalculationRequestValidation :AbstractValidator<CalculationRequest>
{
    public CalculationRequestValidation()
    {
        RuleFor(req => req.Operand1).NotNull();
        //RuleFor(req => req.Operand2).NotNull();
        RuleFor(req => req.Operator).NotNull();
        //.Matches("[+\\-*/]");
        //RuleFor(req => req.Operator).Matches("/").DependentRules(() => {
        //    RuleFor(req => req.Operand2).NotEqual(0).WithMessage("Cannot divide by zero");
        //});
    }
}
