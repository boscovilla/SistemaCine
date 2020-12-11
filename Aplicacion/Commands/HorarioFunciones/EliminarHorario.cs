using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.HorarioFunciones
{
    public class EliminarHorario
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
                var horario = await _context.HorarioFuncion.FindAsync(request.Id);
                if (horario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Horario" });
                }

                _context.HorarioFuncion.Remove(horario);
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
