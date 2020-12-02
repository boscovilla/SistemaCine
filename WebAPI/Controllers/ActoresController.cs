using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActoresController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public ActoresController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<Actor> GetActors()
        {
            return context.Actor.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActorById (int id)
        {
        }
    }
}
