using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;


namespace Aplicacion.Generos
{
    public class Nuevo
    {


        public class Ejecuta :IRequest
        {
         //  [Required(ErrorMessage ="Por favor Ingresa un nombre")]
            public string Nombre { get; set; }
            public string Descripcion { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {

                RuleFor(x => x.Nombre).NotEmpty();
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


                var genero = new Genero
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion

                } ;

                _context.Genero.Add(genero);

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
