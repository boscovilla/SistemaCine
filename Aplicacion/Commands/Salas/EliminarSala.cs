using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Salas
{
    public class EliminarSala
    {
        public class Ejecuta : IRequest
        {
            public int Id { get; set; }
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
                var sala = await _context.Sala.FindAsync(request.Id);
                if (sala == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Horario" });
                }

                _context.Sala.Remove(sala);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al eliminar");
                }

            }
        }
    }
}
