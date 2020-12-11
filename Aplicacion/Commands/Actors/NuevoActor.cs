using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Actors
{
    public class NuevoActor
    {
        public class Ejecutar : IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Nacionalidad { get; set; }
            public int Edad { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecutar>
        {
            private readonly SistemaCineContext _context;
            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                var actor = new Actor()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Nacionalidad = request.Nacionalidad,
                    Edad = request.Edad
                };

                _context.Actor.Add(actor);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("No se pudo agregar datos");
                }
            }
        }
    }
}
