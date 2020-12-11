using FluentValidation;
using static Aplicacion.Commands.Repartos.AgregarReparto;

namespace Aplicacion.Validators
{
    public class RepartoValidator : AbstractValidator<Ejecuta>
    {
        public RepartoValidator()
        {
            RuleFor(c => c.ActorId)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.PeliculaId)
                .NotEmpty()
                .NotNull();
        }
    }
}
