using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Cines
{
    public class ConsultaCinePorId
    {
        public class CineUnico : IRequest<Cine>
        {
            [Required]
            public int CineId { get; set; }
        }

        public class Manejador : IRequestHandler<CineUnico, Cine>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Cine> Handle(CineUnico request, CancellationToken cancellationToken)
            {
                var cine = await _context.Cine.FindAsync(request.CineId);
                if (cine == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el cine" });
                }

                return cine;
            }
        }
    }
}
