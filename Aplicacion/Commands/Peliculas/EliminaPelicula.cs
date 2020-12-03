﻿using MediatR;
using Persistencia;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Peliculas
{
    public class EliminaPelicula
    {
        public class Ejecuta : IRequest
        {
            public int PeliculaId { get; set; }
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
                var movie = await _context.Pelicula.FindAsync(request.PeliculaId);

                if (movie == null)
                {
                    throw new Exception("No se encontro la Pelicula");
                }

                _context.Remove(movie);
                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al eliminar la Pelicula");
                }
            }
        }
    }
}
