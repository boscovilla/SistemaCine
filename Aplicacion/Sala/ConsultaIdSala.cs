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
    public class ConsultaIdSala
    {
        public class SalaUnica : IRequest<Sala>
        {
            public int Id { get; set; }

        }



        public class Manejador : IRequestHandler<SalaUnica, Sala>
        {
            private readonly SistemaCineContext _context;


            public Manejador(SistemaCineContext context)

            {
                _context = context;

            }

            public async Task<Sala> Handle(SalaUnica request, CancellationToken cancellationToken)
            {
                var sala = await _context.Genero.FindAsync(request.Id);

                if (sala == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro la sala" });
                }

                return sala;
            }
        }
    }
}
