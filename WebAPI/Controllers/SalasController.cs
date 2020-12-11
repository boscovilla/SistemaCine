using Aplicacion.Commands.Salas;
using Dominio.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SalasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sala>>> Get()
        {
            return await _mediator.Send(new ConsultaSalas.ListaSalas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sala>> Detalle(int id)
        {
            return await _mediator.Send(new ConsultaPorId.Ejecuta { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(AgregarSala.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, ActualizarSala.Ejecuta data)
        {
            data.SalaId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediator.Send(new EliminarSala.Ejecuta { Id = id });
        }
    }
}
