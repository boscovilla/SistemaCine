using FluentValidation;
using static Aplicacion.Commands.Programaciones.AgregarProgramacion;

namespace Aplicacion.Validators
{
    public class ProgramacionValidator : AbstractValidator<Ejecuta>
    {
        public ProgramacionValidator()
        {
            RuleFor(c => c.FechaFin)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.FechaInicio)
                .NotEmpty()
                .NotNull();
        }
    }
}
