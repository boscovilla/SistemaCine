using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Cines
{
    public class ConsultaCine
    {
        public class ListaCine : IRequest<List<Cine>> { }
        public class Manejador : IRequestHandler<ListaCine, List<Cine>>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<List<Cine>> Handle(ListaCine request, CancellationToken cancellationToken)
            {
                var cines = await _context.Cine.ToListAsync();
                return cines;
            }
        }
    }
}
