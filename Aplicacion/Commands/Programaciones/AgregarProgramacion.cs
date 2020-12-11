using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Programaciones
{
    public class AgregarProgramacion
    {
        public class Ejecuta : IRequest
        {
            [DataType(DataType.Date)]
            public DateTime FechaInicio { get; set; }
            [DataType(DataType.Date)]
            public DateTime FechaFin { get; set; }
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
                var programa = new Programacion()
                {
                    FechaInicio = request.FechaInicio,
                    FechaFin = request.FechaFin
                };

                _context.Programacion.Add(programa);
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
