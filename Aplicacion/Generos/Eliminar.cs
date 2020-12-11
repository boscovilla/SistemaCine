﻿using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Generos
{
    public class Eliminar
    {

        public class Ejecuta : IRequest
        {
            public int Id { get; set; }
      
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

                var genero = await _context.Genero.FindAsync(request.Id);

                if (genero == null)
                {
                    //throw new Exception("No se encontro el genero");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el curso" });
                }

                _context.Remove(genero);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudieron realizar los cambios");
            }
        }
    }
}