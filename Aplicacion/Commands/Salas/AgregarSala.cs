using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Salas
{
    public class AgregarSala
    {
        public class Ejecuta : IRequest
        {
            public int Capacidad { get; set; }
            public string Numero { get; set; }
            public string CineId { get; set; }
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
                var sala = new Sala()
                {
                    Capacidad = request.Capacidad,
                    Numero = request.Numero,
                    CineId = request.CineId
                };

                _context.Sala.Add(sala);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al crear una nueva sala");
                }
            }
        }
    }
}
