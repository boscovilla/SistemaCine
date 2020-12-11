﻿using Aplicacion.ManejadorError;
using Dominio.Entities;
using MediatR;
using Persistencia;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Commands.Funciones
{
    public class EditarFuncion
    {
        public class Ejecuta : IRequest
        {
            public int FuncionId { get; set; }
            public string DiaSemana { get; set; }
            public string HoraInicio { get; set; }
            public int PeliculaId { get; set; }
            public int ProgramacionId { get; set; }
            public int SalaId { get; set; }
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
                var funcion = await _context.Funcion.FindAsync(request.FuncionId);
                if (funcion == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { movie = "Error al Obtener Funcion" });
                }

                funcion.DiaSemana = request.DiaSemana;
                funcion.HoraInicio = request.HoraInicio;
                funcion.PeliculaId = request.PeliculaId;
                funcion.ProgramacionId = request.ProgramacionId;
                funcion.SalaId = request.SalaId;

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("Error al actualizar");
                }
            }
        }
    }
}
