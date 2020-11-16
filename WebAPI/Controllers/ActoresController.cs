
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

        public IEnumerable<Actor> Get()
        {
            return context.Actor.ToList();
        }

        //POST. Actores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateActor(Actor createActor)
        {
            
                context.Actor.Add(createActor);
                await context.SaveChangesAsync();
                return CreatedAtAction(nameof(Get),
                    new Actor { ActorId = createActor.ActorId },
                    createActor);
            
        }


    }
    
}
