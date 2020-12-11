using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.HorarioFunciones
{
    public class ActualizarHorario
    {
        public class Ejecuta : IRequest
        {
            public int HorarioFuncionId { get; set; }
            public string DuracionIntervalo { get; set; }
            public string DuracionPublicidad { get; set; }
            [DataType(DataType.Date)]
            public DateTime HoraPrimeraFuncion { get; set; }
            [DataType(DataType.Date)]
            public DateTime HoraUltimaFuncion { get; set; }
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
                var horario = await _context.HorarioFuncion.FindAsync(request.HorarioFuncionId);
                if (horario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Horarios" });
                }

                horario.DuracionIntervalo = request.DuracionIntervalo;
                horario.DuracionPublicidad = request.DuracionPublicidad;
                horario.HoraPrimeraFuncion = request.HoraPrimeraFuncion;
                horario.HoraUltimaFuncion = request.HoraUltimaFuncion;

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
