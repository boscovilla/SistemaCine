using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sala
{
    public class ConsultaSala
    {
        public class ListaSalas : IRequest<List<Sala>> { }
        public class Manejador : IRequestHandler<ListaSalas, List<Sala>>
        {

            private readonly SistemaCineContext _context;


            public Manejador(SistemaCineContext context)
            {
                _context = context;

            }

            public async Task<List<Sala>> Handle(ListaSalas request, CancellationToken cancellationToken)
            {
                var salas = await _context.Sala.ToListAsync();
                return salas;
            }
        }
    }
}
