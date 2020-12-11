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
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            [Required]
            public int GeneroId { get; set; }
            [Required]
            public string Nombre { get; set; }
            [Required]
            public string Descripcion { get; set; }
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
                var genero = await _context.Genero.FindAsync(request.GeneroId);
                if (genero == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el curso" });
                }

                genero.Nombre = request.Nombre ?? genero.Nombre;
                genero.Descripcion = request.Descripcion ?? genero.Descripcion;

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se guardaron los cambios en los generos");
            }
        }
    }
}
