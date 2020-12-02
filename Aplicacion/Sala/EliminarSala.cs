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

namespace Aplicacion.Sala
{
    public class EliminarSala
    {
        public class Ejecuta : IRequest
        {
            public int SalaId { get; set; }

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

                var sala = await _context.Sala.FindAsync(request.SalaId);

                if (sala == null)
                {
                    //throw new Exception("No se encontro la sala");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro la sala" });
                }

                _context.Remove(sala);

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
