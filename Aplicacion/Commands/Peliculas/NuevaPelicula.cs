using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Peliculas
{
    public class NuevaPelicula
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Duracion { get; set; }
            public string Sinopsis { get; set; }
            public string Director { get; set; }
            [DataType(DataType.Date)]
            public DateTime FechaEstreno { get; set; }
            public string Categoria { get; set; }
            public bool Disponible { get; set; }
            public int GeneroId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var movie = new Pelicula
                {
                    Nombre = request.Nombre,
                    Duracion = request.Duracion,
                    Sinopsis = request.Sinopsis,
                    FechaEstreno = request.FechaEstreno,
                    Categoria = request.Categoria,
                    Disponible = request.Disponible,
                    GeneroId = request.GeneroId
                };

                _context.Pelicula.Add(movie);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al crear una nueva pelicula");
                }
            }
        }
    }
}
