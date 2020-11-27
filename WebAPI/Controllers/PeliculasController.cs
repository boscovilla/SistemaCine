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
    public class PeliculasController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public PeliculasController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        // GET Peliculas
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

        // DELETE: Pelicula/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePelicula(int Id)
        {
            var deleteMovie = await context.Pelicula.FindAsync(Id);
            if (deleteMovie == null)
            {
                return NotFound();
            }

            try
            {
                context.Pelicula.Remove(deleteMovie);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // PUT: Pelicula/id
        [HttpPut("{id}")]
        public async Task<Pelicula> UpdatePelicula(int id, [FromBody] Pelicula movie)
        {
            var findMovie = await context.Pelicula.Where(c => c.PeliculaId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findMovie == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findMovie.Nombre = movie.Nombre;
                    findMovie.Duracion = movie.Duracion;
                    findMovie.Sinopsis = movie.Sinopsis;
                    findMovie.Director = movie.Director;
                    findMovie.FechaEstreno = movie.FechaEstreno;
                    findMovie.Disponible = movie.Disponible;
                    findMovie.RepartoLista = movie.RepartoLista;
                    findMovie.FuncionLista = movie.FuncionLista;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findMovie);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
