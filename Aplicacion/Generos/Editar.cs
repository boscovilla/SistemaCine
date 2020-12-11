﻿using System;
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


namespace Aplicacion.Generos
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public int GeneroId { get; set; }
            public string Nombre { get; set; }
            public string Descripcion { get; set; }

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

                var genero = await _context.Genero.FindAsync(request.GeneroId);

                if (genero == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { genero = "No se encontro el genero" });
                }

                genero.Nombre = request.Nombre ?? genero.Nombre;
                genero.Descripcion = request.Descripcion ?? genero.Descripcion;

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
