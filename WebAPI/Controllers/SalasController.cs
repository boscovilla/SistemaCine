
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Aplicacion.Seguridad;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public SalasController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<Sala> Get()
        {
            return context.Sala.ToList();
        }
    }
}
