using FluentValidation;
using static Aplicacion.Commands.Salas.AgregarSala;

namespace Aplicacion.Validators
{
    public class SalaValidator : AbstractValidator<Ejecuta>
    {
        public SalaValidator()
        {
            RuleFor(c => c.Capacidad)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Numero)
                .NotNull()
                .NotEmpty();
        }
    }
}
