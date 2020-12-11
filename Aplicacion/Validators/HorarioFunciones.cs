using FluentValidation;
using static Aplicacion.Commands.HorarioFunciones.AgregarHorario;

namespace Aplicacion.Validators
{
    public class HorarioFunciones : AbstractValidator<Ejecuta>
    {
        public HorarioFunciones()
        {
            RuleFor(c => c.DuracionIntervalo)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.HoraPrimeraFuncion)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.HoraUltimaFuncion)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.DuracionPublicidad)
                .NotNull()
                .NotEmpty();
        }
    }
}
