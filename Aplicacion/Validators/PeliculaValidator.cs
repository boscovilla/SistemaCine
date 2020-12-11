using FluentValidation;
using static Aplicacion.Commands.Peliculas.NuevaPelicula;

namespace Aplicacion.Validators
{
    public class PeliculaValidator : AbstractValidator<Ejecuta>
    {
        public PeliculaValidator()
        {
            RuleFor(c => c.Nombre)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Duracion)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.Sinopsis)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.FechaEstreno)
                .NotEmpty()
                .NotNull();

            RuleFor(c => c.GeneroId)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Director)
                .NotNull()
                .NotEmpty();

            RuleFor(c => c.Categoria)
                .NotEmpty()
                .NotEmpty();
        }
    }
}
