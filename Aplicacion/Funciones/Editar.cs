using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Funciones
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public int FuncionId { get; set; }
            public string DiaSemana { get; set; }
            public string HoraInicio { get; set; }
            public string Duracion { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            public readonly SistemaCineContext _context;

            public Manejador(SistemaCineContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var funcion = await _context.Funcion.FindAsync(request.FuncionId);


                if (funcion == null)
                {

                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { funcion = "No se encontro la funcion" });
                }

                funcion.DiaSemana = request.DiaSemana ?? funcion.DiaSemana;
                funcion.HoraInicio = request.HoraInicio ?? funcion.HoraInicio;
                funcion.Duracion = request.Duracion ?? funcion.Duracion;

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
