using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Cines
{
    public class CrearCine
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public float PrecioEntradaGeneral { get; set; }
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
                var cine = new Cine()
                {
                    Nombre = request.Nombre,
                    Direccion = request.Direccion,
                    PrecioEntradaGeneral = request.PrecioEntradaGeneral
                };

                _context.Cine.Add(cine);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al crear registro");
                }
            }
        }
    }
}
