using Aplicacion.Commands.HorarioFunciones;
using Dominio.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosFuncionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HorariosFuncionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<HorarioFuncion>>> Get()
        {
            return await _mediator.Send(new Consulta.ListaHorarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HorarioFuncion>> Detalle(int id)
        {
            return await _mediator.Send(new ConsultaHorarioPorId.Ejecuta { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(AgregarHorario.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, ActualizarHorario.Ejecuta data)
        {
            data.HorarioFuncionId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediator.Send(new EliminarHorario.Ejecuta { Id = id });
        }
    }
}
