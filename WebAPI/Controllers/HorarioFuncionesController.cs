using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosFuncionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public HorariosFuncionesController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<HorarioFuncion> Get()
        {
            return context.HorarioFuncion.ToList();
        }
    }
}
