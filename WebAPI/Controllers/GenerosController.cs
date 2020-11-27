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
    public class GenerosController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public GenerosController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        //GET Generos
        [HttpGet]
        public IEnumerable<Genero> GetGenero()
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
            return CreatedAtAction(nameof(GetGenero),
                new Genero { GeneroId = createGenero.GeneroId },
                createGenero);
        }

        // DELETE: Genero/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenero(int Id)
        {
            var deleteGenero = await context.Genero.FindAsync(Id);
            if (deleteGenero == null)
            {
                return NotFound();
            }

            try
            {
                context.Genero.Remove(deleteGenero);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // PUT: Genero/id
        [HttpPut("{id}")]
        public async Task<Genero> UpdateGenero(int id, [FromBody] Genero genero)
        {
            var findGenero = await context.Genero.Where(c => c.GeneroId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findGenero == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findGenero.TipoGenero = genero.TipoGenero;
                    findGenero.Descripcion = genero.Descripcion;
                    findGenero.Pelicula = genero.Pelicula;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findGenero);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
