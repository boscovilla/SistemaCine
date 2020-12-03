using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Generos
{
    public class Consulta
    {
        public class ListaGeneros : IRequest<List<Genero>> { }
        public class Manejador : IRequestHandler<ListaGeneros, List<Genero>>
        {
            private readonly SistemaCineContext _context;

            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }

            public async Task<List<Genero>> Handle(ListaGeneros request, CancellationToken cancellationToken)
            {
                var generos = await _context.Genero.ToListAsync();
                return generos;
            }
        }
    }
}
