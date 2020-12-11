using FluentValidation;
using static Aplicacion.Commands.Generos.Nuevo;

namespace Aplicacion.Validators
{
    public class GeneroValidator : AbstractValidator<Ejecuta>
    {
        public GeneroValidator()
        {
            RuleFor(c => c.Nombre)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Descripcion)
                .NotNull()
                .NotEmpty();
        }
    }
}
