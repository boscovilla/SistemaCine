using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Salas
{
    public class ConsultaPorId
    {
        public class Ejecuta : IRequest<Sala>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Sala>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Sala> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var sala = await _context.Sala.FindAsync(request.Id);
                if (sala == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Horarios" });
                }

                return sala;
            }
        }
    }
}
