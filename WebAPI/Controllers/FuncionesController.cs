
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Aplicacion.Funciones;

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
            return await _mediator.Send(new Consulta.ListaFunciones());
        }
    }
}
