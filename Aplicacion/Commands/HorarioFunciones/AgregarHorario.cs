using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.HorarioFunciones
{
    public class AgregarHorario
    {
        public class Ejecuta : IRequest
        {
            public string DuracionIntervalo { get; set; }
            public string DuracionPublicidad { get; set; }
            [DataType(DataType.Date)]
            public DateTime HoraPrimeraFuncion { get; set; }
            [DataType(DataType.Date)]
            public DateTime HoraUltimaFuncion { get; set; }
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
                var horario = new HorarioFuncion()
                {
                    DuracionIntervalo = request.DuracionIntervalo,
                    DuracionPublicidad = request.DuracionPublicidad,
                    HoraPrimeraFuncion = request.HoraPrimeraFuncion,
                    HoraUltimaFuncion = request.HoraUltimaFuncion,
                    CineId = request.CineId
                };

                _context.HorarioFuncion.Add(horario);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al crear un nuevo horario");
                }
            }
        }
    }
}
