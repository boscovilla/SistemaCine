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
    public class RepartosController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public RepartosController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        // GET Repartos
        [HttpGet]
        public IEnumerable<Reparto> Get()
        {
            return context.Reparto.ToList();
        }

        //POST. Repartos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReparto(Reparto createReparto)
        {
            context.Reparto.Add(createReparto);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new Reparto { RepartoId = createReparto.RepartoId },
                createReparto);
        }

        // DELETE: Reparto/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReparto(int Id)
        {
            var deleteReparto = await context.Reparto.FindAsync(Id);
            if (deleteReparto == null)
            {
                return NotFound();
            }

            try
            {
                context.Reparto.Remove(deleteReparto);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // DELETE: Reparto/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int Id)
        {
            var deleteReparto = await context.Reparto.FindAsync(Id);
            if (deleteReparto == null)
            {
                return NotFound();
            }

            try
            {
                context.Reparto.Remove(deleteReparto);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // PUT: Reparto/id
        [HttpPut("{id}")]
        public async Task<Reparto> UpdateActor(int id, [FromBody] Reparto reparto)
        {
            var findReparto = await context.Reparto.Where(c => c.RepartoId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findReparto == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findReparto.ActorId = reparto.ActorId;
                    findReparto.PeliculaId = reparto.PeliculaId;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findReparto);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
