using Dominio;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Generos
{
  public  class Consulta
    {

        public class ListaGeneros:IRequest<List<Genero>> { }
        public class Manejador : IRequestHandler<ListaGeneros, List<Genero>>
        {

            private readonly SistemaCineContext _context;


            public Manejador (SistemaCineContext context)
            {
                _context = context;

            }

            public async Task<List<Genero>> Handle(ListaGeneros request, CancellationToken cancellationToken)
            {
                var generos = await _context.Genero.ToListAsync();
                return generos;
            }
        }
    }
}
