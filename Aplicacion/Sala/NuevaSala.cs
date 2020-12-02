using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Sala
{
    public class NuevaSala
    {
        public class Ejecuta : IRequest
        {
            //  [Required(ErrorMessage ="Por favor Ingresa un nombre")]
            public int Capacidad { get; set; }
            public string Numero { get; set; }
            public string CineId { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {

                RuleFor(x => x.Numero).NotEmpty();
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


                var sala = new Sala
                {
                    Capacidad = request.Capacidad,
                    Numero = request.Numero,
                    CineId = request.CineId

                };

                _context.Genero.Add(sala);

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
