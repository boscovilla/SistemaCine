using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Actors
{
    public class ConsultaActor
    {
        public class ListaActores : IRequest<List<Actor>> { }
        public class Manejador : IRequestHandler<ListaActores, List<Actor>>
        {
            private readonly SistemaCineContext _context;

            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }

            public async Task<List<Actor>> Handle(ListaActores request, CancellationToken cancellationToken)
            {
                var actores = await _context.Actor.ToListAsync();
                return actores;
            }
        }
    }
}
