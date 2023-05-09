using FluentValidation;
using WebCalculator.Domain;
using WebCalculator.Models;

namespace WebCalculator.Validations;

public class CalculationRequestValidation : AbstractValidator<CalculationRequest>
{
    public CalculationRequestValidation()
    {

        RuleFor(request => request.Operator)
            .NotNull()
            .Must(Constants.SupportedOperators.Contains)
            .WithMessage("Please only use one of the supported operators: " + String.Join(" ", Constants.SupportedOperators));

        RuleFor(request => request.Operand1)
            .NotNull()
            .When(x => Constants.UnaryOperators.Contains(x.Operator))
            .WithMessage("Operand1 is required with unary operators: " + String.Join(" ", Constants.UnaryOperators));

        When(x => Constants.BinaryOperators.Contains(x.Operator), () =>
        {
            RuleFor(x => x.Operand1).NotNull()
                .WithMessage("Operand2 is required with binary operators: " + String.Join(" ", Constants.BinaryOperators)); 
            RuleFor(x => x.Operand2).NotNull()
                .WithMessage("Operand2 is required with binary operators: " + String.Join(" ", Constants.BinaryOperators));
        });
    }
}
