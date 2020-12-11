using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.HorarioFunciones
{
    public class Consulta
    {
        public class ListaHorarios : IRequest<List<HorarioFuncion>> { }

        public class Manejador : IRequestHandler<ListaHorarios, List<HorarioFuncion>>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<List<HorarioFuncion>> Handle(ListaHorarios request, CancellationToken cancellationToken)
            {
                var horario = await _context.HorarioFuncion.ToListAsync();
                if (horario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al listar horarios" });
                }

                return horario;
            }
        }

    }
}
