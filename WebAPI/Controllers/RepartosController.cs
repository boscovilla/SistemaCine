using Dominio.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Commands.Repartos;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RepartosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RepartosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reparto>>> Get()
        {
            return await _mediator.Send(new ConsultarRepartos.ListaReparto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reparto>> Detalle(int id)
        {
            return await _mediator.Send(new ConsultaPorId.Ejecuta { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(AgregarReparto.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, ActualizarReparto.Ejecuta data)
        {
            data.RepartoId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediator.Send(new EliminarReparto.Ejecuta { Id = id });
        }
    }
}
