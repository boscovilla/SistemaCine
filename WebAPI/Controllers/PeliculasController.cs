using Aplicacion.Commands.Peliculas;
using Dominio.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PeliculasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> Get()
        {
            return await _mediator.Send(new ConsultaPelicula.ListaPeliculas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> Detalle(int id)
        {
            return await _mediator.Send(new ConsultaPeliculaPorId.PeliculaUnica { PeliculaId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevaPelicula.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, EditarPelicula.Ejecuta data)
        {
            data.PeliculaId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediator.Send(new EliminaPelicula.Ejecuta { PeliculaId = id });
        }
    }
}
