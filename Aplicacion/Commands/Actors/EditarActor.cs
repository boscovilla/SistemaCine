using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Actors
{
    public class EditarActor
    {
        public class Ejecuta : IRequest
        {
            [Required]
            public int ActorId { get; set; }
            [Required]
            public string Nombre { get; set; }
            [Required]
            public string Apellido { get; set; }
            [Required]
            public string Nacionalidad { get; set; }
            [Required]
            public int Eddad { get; set; }
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
                var actor = await _context.Actor.FindAsync(request.ActorId);

                if (actor == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { actor = "No se encontro el actor" });
                }
                actor.Nombre = request.Nombre ?? actor.Nombre;
                actor.Apellido = request.Apellido ?? actor.Apellido;
                actor.Nacionalidad = request.Nacionalidad ?? actor.Nacionalidad;
                actor.Edad = request.Eddad;

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al actualizar");
                }

            }
        }
    }
}
