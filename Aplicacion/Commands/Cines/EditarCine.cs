using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;

namespace Aplicacion.Commands.Cines
{
    public class EditarCine
    {
        public class Ejecuta : IRequest
        {
            public int CineId { get; set; }
            public string NombreCine { get; set; }
            public string Direccion { get; set; }
            public string PrecioEntradaGeneral { get; set; }
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
                var cine = await _context.Cine.FindAsync(request.CineId);
                if (cine == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el Cine" });
                }

                cine.Nombre = request.NombreCine;
                cine.Direccion = request.Direccion;

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
