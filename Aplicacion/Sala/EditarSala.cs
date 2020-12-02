using System;
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

namespace Aplicacion.Sala
{
    public class EditarSala
    {
        public class Ejecuta : IRequest
        {
            public int SalaId { get; set; }
            public int Capacidad { get; set; }
            public string Numero { get; set; }
            public string CineId { get; set; }

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

                var sala = await _context.Genero.FindAsync(request.SalaId);


                if (sala == null)
                {
                    //   throw new Exception("La Sala No Existe");
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontro la sala" });

                }

                sala.Capacidad = request.Capacidad ?? sala.Capacidad;
                sala.Numero = request.Numero ?? sala.Numero;
                sala.CineId = request.CineId ?? sala.CineId;

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;

                }

                throw new Exception("No se guardaron los cambios en las salas");



            }
        }
    }
}
