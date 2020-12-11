using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Funciones
{
    public class ConsultaFuncion
    {
        public class ListaFuncion : IRequest<List<Funcion>> { }

        public class Manejador : IRequestHandler<ListaFuncion, List<Funcion>>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<List<Funcion>> Handle(ListaFuncion request, CancellationToken cancellationToken)
            {
                var funcion = await _context.Funcion.ToListAsync();
                return funcion;
            }
        }
    }
}
