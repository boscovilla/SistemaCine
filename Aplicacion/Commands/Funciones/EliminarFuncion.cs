using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Funciones
{
    public class EliminarFuncion
    {
        public class Ejecuta : IRequest
        {
            public int FuncionId { get; set; }
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
                var funcion = await _context.Funcion.FindAsync(request.FuncionId);
                if (funcion == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al Obtener Funcion" });
                }

                _context.Funcion.Remove(funcion);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al eliminar la Funcion");
                }
            }
        }
    }
}
