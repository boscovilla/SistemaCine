
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
    public class CinesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public CinesController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<Cine> Get()
        {
            return context.Cine.ToList();
        }

        //POST. Cines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCine(Cine createCine)
        {

            context.Cine.Add(createCine);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new Cine { CineId = createCine.CineId },
                createCine);



        }

        // DELETE: Cines/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteCine(int CineId)
        {
            var deleteCine = await context.Cine.FindAsync(CineId);
            if (deleteCine == null)
            {
                return NotFound();
            }

            context.Cine.Remove(deleteCine);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
