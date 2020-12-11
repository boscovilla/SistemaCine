using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Repartos
{
    public class AgregarReparto
    {
        public class Ejecuta : IRequest
        {
            public int ActorId { get; set; }
            public int PeliculaId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var reparto = new Reparto()
                {
                    ActorId = request.ActorId,
                    PeliculaId = request.PeliculaId
                };

                _context.Reparto.Add(reparto);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al crear un nuevo reparto");
                }
            }
        }

    }
}
