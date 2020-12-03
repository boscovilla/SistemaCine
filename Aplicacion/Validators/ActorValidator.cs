using FluentValidation;
using static Aplicacion.Commands.Actors.NuevoActor;

namespace Aplicacion.Validators
{
    public class ActorValidator : AbstractValidator<Ejecutar>
    {
        public ActorValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.LastName)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Nacionality)
                .NotEmpty()
                .NotNull();
        }
    }
}
