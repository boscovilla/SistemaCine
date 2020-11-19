
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
    public class GenerosController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public GenerosController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<Genero> Get()
        {
            return context.Genero.ToList();
        }

        //POST. Genero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGenero(Genero createGenero)
        {

            context.Genero.Add(createGenero);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new Genero { GeneroId = createGenero.GeneroId },
                createGenero);



        }

        // DELETE: Genero/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteGenero(int GeneroId)
        {
            var deleteGenero = await context.Genero.FindAsync(GeneroId);
            if (deleteGenero == null)
            {
                return NotFound();
            }

            context.Genero.Remove(deleteGenero);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
