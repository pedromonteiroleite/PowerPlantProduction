using FluentValidation;

namespace Application.DailyTemperature.Commands.CreateDailyTemperature;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateDailyTemperatureCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.HighTemp)
            .NotEmpty()
            .NotNull();

        RuleFor(v => v.LowTemp)
            .NotEmpty()
            .NotNull();

        RuleFor(v => v.LowTemp)
            .LessThanOrEqualTo(v => v.HighTemp);
    }
}
