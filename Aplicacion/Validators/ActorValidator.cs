using FluentValidation;
using static Aplicacion.Commands.Actors.NuevoActor;

namespace Aplicacion.Validators
{
    public class ActorValidator : AbstractValidator<Ejecutar>
    {
        public ActorValidator()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Apellido)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Nacionalidad)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Edad)
                .NotEmpty()
                .NotNull();
        }
    }
}
