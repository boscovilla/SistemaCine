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

        // GET Actores 
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

        // DELETE: Actores/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteActor(int Id)
        {
            var deleteActor = await context.Actor.FindAsync(Id);
            if (deleteActor == null)
            {
                return NotFound();
            }

            context.Actor.Remove(deleteActor);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }

}
