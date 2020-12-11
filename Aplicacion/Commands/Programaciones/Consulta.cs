using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Programaciones
{
    public class Consulta
    {
        public class ListaProgramacion : IRequest<List<Programacion>> { }

        public class Manejador : IRequestHandler<ListaProgramacion, List<Programacion>>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<List<Programacion>> Handle(ListaProgramacion request, CancellationToken cancellationToken)
            {
                var programa = await _context.Programacion.ToListAsync();
                if (programa == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar las programaciones" });
                }

                return programa;
            }
        }

    }
}
