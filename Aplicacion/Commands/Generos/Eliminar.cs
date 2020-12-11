using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Generos
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            [Required]
            public int Id { get; set; }
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
                var genero = await _context.Genero.FindAsync(request.Id);

                if (genero == null)
                {
                    //throw new Exception("No se encontro el genero");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el curso" });
                }

                _context.Genero.Remove(genero);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudieron realizar los cambios");
            }
        }
    }
}
