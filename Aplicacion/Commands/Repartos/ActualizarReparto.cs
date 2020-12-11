using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Repartos
{
    public class ActualizarReparto
    {
        public class Ejecuta : IRequest
        {
            public int RepartoId { get; set; }
            public int ActorId { get; set; }
            public int PeliculaId { get; set; }
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
                var reparto = await _context.Reparto.FindAsync(request.RepartoId);
                if (reparto == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Horarios" });
                }

                reparto.ActorId = request.ActorId;
                reparto.PeliculaId = request.PeliculaId;

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al actualizar");
                }
            }

        }
    }
}
