using Aplicacion.Seguridad;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UsuariosController : MiControllerBase

    { 
        [HttpPost("login")]

        public async Task<ActionResult<UsuarioData>> Login(Login.Ejecuta parametros)
    {
        return await Mediator.Send(parametros);
    }
}
}
