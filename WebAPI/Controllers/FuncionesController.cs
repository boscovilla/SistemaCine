using Aplicacion.Commands.Funciones;
using Dominio.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FuncionesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Funcion>>> Get()
        {
            return await _mediator.Send(new ConsultaFuncion.ListaFuncion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Funcion>> Detalle(int id)
        {
            return await _mediator.Send(new ConsultarFuncionPorId.FuncionUnica { FuncionId = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(AgregarFuncion.Ejecuta data)
        {
            return await _mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(int id, EditarFuncion.Ejecuta data)
        {
            data.FuncionId = id;
            return await _mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(int id)
        {
            return await _mediator.Send(new EliminarFuncion.Ejecuta { FuncionId = id });
        }
    }
}
