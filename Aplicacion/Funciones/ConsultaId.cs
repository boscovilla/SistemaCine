using Dominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Persistencia;
using Microsoft.EntityFrameworkCore;
using Aplicacion.ManejadorError;
using System.Net;

namespace Aplicacion.Funciones
{
    public class ConsultaId
    {


        public class FuncionUnico : IRequest<Funcion>
        {
            public int Id { get; set; }


            public class Manejador : IRequestHandler<FuncionUnico, Funcion>
            {

                private readonly SistemaCineContext _context;


                public Manejador(SistemaCineContext context)
                {
                    _context = context;

                }

                public async Task<Funcion> Handle(FuncionUnico request, CancellationToken cancellationToken)
                {

                    var funcion = await _context.Funcion.FindAsync(request.Id);

                    if (funcion == null)
                    {
                        throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el curso" });
                    }

                    return funcion;
                }
            }
        }
    }
}
