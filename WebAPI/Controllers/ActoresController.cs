using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
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
        public IEnumerable<Actor> GetActor()
        {
            return context.Actor.ToList();
        }

        //POST. Actor/Create
        [HttpPost]
        public async Task<IActionResult> CreateActor(Actor createActor)
        {
            context.Actor.Add(createActor);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetActor),
                new Actor { ActorId = createActor.ActorId },
                createActor);
        }

        // DELETE: Actor/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int Id)
        {
            var deleteActor = await context.Actor.FindAsync(Id);
            if (deleteActor == null)
            {
                return NotFound();
            }

            try
            {
                context.Actor.Remove(deleteActor);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // PUT: Actor/id
        [HttpPut("{id}")]
        public async Task<Actor> UpdateActor(int id, [FromBody] Actor actor)
        {
            var findActor = await context.Actor.Where(c => c.ActorId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findActor == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findActor.Nombre = actor.Nombre;
                    findActor.Apellido = actor.Apellido;
                    findActor.Nacionalidad = actor.Nacionalidad;
                    findActor.Edad = actor.Edad;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findActor);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
