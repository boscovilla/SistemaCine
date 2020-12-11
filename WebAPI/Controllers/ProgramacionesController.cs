using Aplicacion.Commands.Programaciones;
using Dominio.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramacionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProgramacionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Programacion>>> Get()
        {
            return await _mediator.Send(new Consulta.ListaProgramacion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Programacion>> Detalle(int id)
        {
            return await _mediator.Send(new ConsultaPorId.Ejecuta { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(AgregarProgramacion.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, ActualizarProgramacion.Ejecuta data)
        {
            data.ProgramacionId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediator.Send(new EliminarProgramacion.Ejecuta { Id = id });
        }
    }
}
