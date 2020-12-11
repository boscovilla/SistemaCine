using FluentValidation;
using static Aplicacion.Commands.Funciones.AgregarFuncion;

namespace Aplicacion.Validators
{
    public class FuncionValidator : AbstractValidator<Ejecuta>
    {
        public FuncionValidator()
        {
            RuleFor(c => c.DiaSemana)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Duracion)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.HoraInicio)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.PeliculaId)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.ProgramacionId)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.SalaId)
                .NotNull()
                .NotEmpty();
        }
    }
}
