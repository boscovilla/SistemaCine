using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Actors
{
    public class EliminarActor
    {
        public class Ejecutar : IRequest
        {
            public int ActorId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecutar>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var actor = await _context.Actor.FindAsync(request.ActorId);

                if (actor == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el actor" });
                }

                _context.Actor.Remove(actor);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Eror el Eliminar el Actor");
                }
            }
        }
    }
}
