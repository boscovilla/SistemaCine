using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Repartos
{
    public class ConsultarRepartos
    {
        public class ListaReparto : IRequest<List<Reparto>> { }

        public class Manejador : IRequestHandler<ListaReparto, List<Reparto>>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<List<Reparto>> Handle(ListaReparto request, CancellationToken cancellationToken)
            {
                var reparto = await _context.Reparto.ToListAsync();
                if (reparto == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar horarios" });
                }

                return reparto;
            }
        }

    }
}
