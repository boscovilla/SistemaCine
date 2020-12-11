using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Salas
{
    public class ConsultaSalas
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
                var sala = await _context.Sala.ToListAsync();
                if (sala == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar Salas" });
                }

                return sala;
            }
        }

    }
}
