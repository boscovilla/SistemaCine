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
    public class ConsultaId
    {


        public class GeneroUnico : IRequest<Genero>
        {
            public int Id { get; set; }

        }



        public class Manejador : IRequestHandler<GeneroUnico , Genero>
        {
            private readonly SistemaCineContext _context;


            public Manejador(SistemaCineContext context)

            {
                _context = context;

            }

            public async Task<Genero> Handle(GeneroUnico request, CancellationToken cancellationToken)
            {
                var genero = await _context.Genero.FindAsync(request.Id);

                if (genero == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro el curso" });
                }

                return genero; 
            }
        }



    }
}