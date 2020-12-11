using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Funciones
{
    public class ConsultarFuncionPorId
    {
        public class FuncionUnica : IRequest<Funcion>
        {
            public int FuncionId { get; set; }
        }

        public class Manejador : IRequestHandler<FuncionUnica, Funcion>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Funcion> Handle(FuncionUnica request, CancellationToken cancellationToken)
            {
                var funcion = await _context.Funcion.FindAsync(request.FuncionId);
                if (funcion == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al Obtener Funcion" });
                }

                return funcion;
            }
        }
    }
}
