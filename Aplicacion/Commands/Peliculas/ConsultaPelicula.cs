using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Peliculas
{
    public class ConsultaPelicula
    {
        public class ListaPeliculas : IRequest<List<Pelicula>> { }
        public class Manejador : IRequestHandler<ListaPeliculas, List<Pelicula>>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<List<Pelicula>> Handle(ListaPeliculas request, CancellationToken cancellationToken)
            {
                var movie = await _context.Pelicula.ToListAsync();

                if (movie == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar peliculas" });
                }
                return movie;
            }
        }
    }
}
