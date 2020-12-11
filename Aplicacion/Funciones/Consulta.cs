using Dominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Funciones
{
    public class Consulta
    {

        public class ListaFunciones : IRequest<List<Funcion>> { }
        public class Manejador : IRequestHandler<ListaFunciones, List<Funcion>>
        {

            private readonly SistemaCineContext _context;


            public Manejador(SistemaCineContext context)
            {
                _context = context;

            }

            public async Task<List<Funcion>> Handle(ListaFunciones request, CancellationToken cancellationToken)
            {
                var funciones= await _context.Funcion.ToListAsync();
                return funciones;
            }

        }
    }
}
