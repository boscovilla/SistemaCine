using Aplicacion.Commands.Actors;
using Dominio.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActoresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Actor>>> Get()
        {
            return await _mediator.Send(new ConsultaActor.ListaActores());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> Detalle(int id)
        {
            return await _mediator.Send(new ConsultaActorPorId.ActorUnico { ActorId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoActor.Ejecutar data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, EditarActor.Ejecuta data)
        {
            data.ActorId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediator.Send(new EliminarActor.Ejecutar { ActorId = id });
        }
    }
}
