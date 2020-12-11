using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.HorarioFunciones
{
    public class ConsultaHorarioPorId
    {
        public class Ejecuta : IRequest<HorarioFuncion>
        {
            [Required]
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, HorarioFuncion>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<HorarioFuncion> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var horario = await _context.HorarioFuncion.FindAsync(request.Id);
                if (horario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Horarios" });
                }

                return horario;
            }
        }
    }
}
