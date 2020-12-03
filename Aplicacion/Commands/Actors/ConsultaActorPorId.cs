using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Actors
{
    public class ConsultaActorPorId
    {
        public class ActorUnico : IRequest<Actor>
        {
            public int ActorId { get; set; }
        }

        public class Manejador : IRequestHandler<ActorUnico, Actor>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }

            public async Task<Actor> Handle(ActorUnico request, CancellationToken cancellation)
            {
                var actor = await _context.Actor.FindAsync(request.ActorId);

                if (actor == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { actor = "No se encontro el actor" });
                }

                return actor;
            }
        }
    }
}
