using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Funciones
{
    public class AgregarFuncion
    {
        public class Ejecuta : IRequest
        {
            public string DiaSemana { get; set; }
            public string HoraInicio { get; set; }
            public string Duracion { get; set; }
            public int PeliculaId { get; set; }
            public int ProgramacionId { get; set; }
            public int SalaId { get; set; }
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
                var funcion = new Funcion()
                {
                    DiaSemana = request.DiaSemana,
                    HoraInicio = request.HoraInicio,
                    Duracion = request.Duracion,
                    PeliculaId = request.PeliculaId,
                    ProgramacionId = request.ProgramacionId,
                    SalaId = request.SalaId
                };

                _context.Funcion.Add(funcion);

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al crear una nueva funcion");
                }

            }
        }
    }
}
