using FluentValidation;
using static Aplicacion.Commands.Cines.CrearCine;

namespace Aplicacion.Validators
{
    public class CineValidator : AbstractValidator<Ejecuta>
    {
        public CineValidator()
        {
            RuleFor(c => c.Direccion)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Nombre)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.PrecioEntradaGeneral)
                .NotEmpty()
                .NotNull();
        }
    }
}
