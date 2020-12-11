using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Repartos
{
    public class ConsultaPorId
    {
        public class Ejecuta : IRequest<Reparto>
        {
            [Required]
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Reparto>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Reparto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var reparto = await _context.Reparto.FindAsync(request.Id);
                if (reparto == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Horarios" });
                }

                return reparto;
            }
        }
    }
}
