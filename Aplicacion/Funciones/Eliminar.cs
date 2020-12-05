using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Funciones
{
    public class Eliminar
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

                var funcion = await _context.Funcion.FindAsync(request.Id);

                if (funcion == null)
                {
                    //throw new Exception("No se encontro el genero");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { funcion = "No se encontro la funcion" });
                }

                _context.Remove(funcion);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudieron realizar los cambios");
            }
        }
    }
}
