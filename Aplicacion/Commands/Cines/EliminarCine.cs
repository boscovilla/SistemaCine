using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Cines
{
    public class EliminarCine
    {
        public class Ejecuta : IRequest
        {
            [Required]
            public int CineId { get; set; }
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
                var cine = await _context.Cine.FindAsync(request.CineId);
                if (cine == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el cine" });
                }

                _context.Cine.Remove(cine);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al Eliminar");
                }
            }
        }
    }
}
