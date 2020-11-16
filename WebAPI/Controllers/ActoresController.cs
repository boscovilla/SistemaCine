
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

        public IEnumerable<Actor> GetActor()
        {
            return context.Actor.ToList();
        }

        public async Task<ActionResult<Actor>> CreateActor(Actor createActor)
        {
            context.Actor.Add(createActor);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetActor), new Actor {ActorId = createActor.ActorId}, createActor);
        }
    }
}
