using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Programaciones
{
    public class ActualizarProgramacion
    {
        public class Ejecuta : IRequest
        {
            [Required]
            public int ProgramacionId { get; set; }
            [Required]
            [DataType(DataType.Date)]
            public DateTime FechaInicio { get; set; }
            [Required]
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
                var programa = await _context.Programacion.FindAsync(request.ProgramacionId);
                if (programa == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar la Programacion" });
                }

                programa.FechaFin = request.FechaFin;
                programa.FechaInicio = request.FechaInicio;

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
