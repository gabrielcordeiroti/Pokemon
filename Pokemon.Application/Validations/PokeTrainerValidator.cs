using FluentValidation;
using Pokemon.Domain.Entities;

namespace Pokemon.Application.Validations
{
    public class PokeTrainerValidator : AbstractValidator<PokeTrainer>
    {
        public PokeTrainerValidator()
        {
            RuleFor(pk => pk.Name)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .NotEmpty()
                .WithMessage("It is necessary to enter a name for the Pokemon Trainer, with a minimum of 3 and a maximum of 150 characters");

            RuleFor(pk => pk.Age)
                .NotNull()
                .NotEmpty()
                .WithMessage("It is necessary to inform the age of the Pokemon Trainer");

            RuleFor(pk => pk.CPF)
                .NotNull()
                .MaximumLength(11)
                .NotEmpty()
                .WithMessage("It is necessary to inform the CPF of the Pokemon Traine");
        }

    }
}
