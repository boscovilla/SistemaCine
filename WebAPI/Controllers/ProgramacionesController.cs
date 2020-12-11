using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramacionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public ProgramacionesController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<Programacion> Get()
        {
            return context.Programacion.ToList();
        }
    }
}
