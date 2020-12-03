using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Peliculas
{
    public class ConsultaPeliculaPorId
    {
        public class PeliculaUnica : IRequest<Pelicula>
        {
            public int PeliculaId { get; set; }
        }

        public class Manejador : IRequestHandler<PeliculaUnica, Pelicula>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Pelicula> Handle(PeliculaUnica request, CancellationToken cancellationToken)
            {
                var movie = await _context.Pelicula.FindAsync(request.PeliculaId);

                if (movie == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al Obtener Pelicula" });
                }

                return movie;
            }
        }
    }
}
