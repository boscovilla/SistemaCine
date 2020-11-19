
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
    public class PeliculasController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public PeliculasController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<Pelicula> Get()
        {
            return context.Pelicula.ToList();
        }

        //POST. Peliculas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePeliculas(Pelicula createPelicula)
        {

            context.Pelicula.Add(createPelicula);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new Pelicula { PeliculaId = createPelicula.PeliculaId },
                createPelicula);



        }

        // DELETE: Peliculas/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePelicula(int PeliculaId)
        {
            var deletePelicula = await context.Pelicula.FindAsync(PeliculaId);
            if (deletePelicula == null)
            {
                return NotFound();
            }

            context.Pelicula.Remove(deletePelicula);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
