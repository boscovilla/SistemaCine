using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Dominio.Entities;
using Persistencia;
using System.Threading.Tasks;
using System.Threading;
using Aplicacion.ManejadorError;
using System.Net;

namespace Aplicacion.Commands.Programaciones
{
    public class ConsultaPorId
    {
        public class Ejecuta : IRequest<Programacion>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, Programacion>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Programacion> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var programa = await _context.Programacion.FindAsync(request.Id);
                if (programa == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar la Programacion" });
                }

                return programa;
            }
        }

    }
}
