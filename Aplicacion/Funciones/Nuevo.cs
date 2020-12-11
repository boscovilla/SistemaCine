using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;


namespace Aplicacion.Funciones
{
    public class Nuevo
    {


        public class Ejecuta : IRequest
        { 
            public int FuncionId { get; set; }
            public string DiaSemana { get; set; }
            public string HoraInicio { get; set; }
            public string Duracion { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.DiaSemana).NotEmpty();
            }

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


                var funcion = new Funcion
                {
                    DiaSemana = request.DiaSemana,
                    HoraInicio = request.HoraInicio,
                    Duracion = request.Duracion

                };

                _context.Funcion.Add(funcion);

                var valor = await _context.SaveChangesAsync();

                if (valor > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo agregar datos");


            }


        }


    }
}
