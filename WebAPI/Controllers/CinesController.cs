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
    public class CinesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public CinesController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        // GET Cines
        [HttpGet]
        public IEnumerable<Cine> GetCine()
        {
            return context.Cine.ToList();
        }

        //POST Cines/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCine(Cine createCine)
        {
            context.Cine.Add(createCine);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCine),
                new Cine { CineId = createCine.CineId },
                createCine);
        }

        // DELETE: Cine/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int Id)
        {
            var deleteCine = await context.Cine.FindAsync(Id);
            if (deleteCine == null)
            {
                return NotFound();
            }

            try
            {
                context.Cine.Remove(deleteCine);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // PUT: Cine/id
        [HttpPut("{id}")]
        public async Task<Cine> UpdateCine(int id, [FromBody] Cine cine)
        {
            var findCine = await context.Cine.Where(c => c.CineId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findCine == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findCine.Nombre = cine.Nombre;
                    findCine.Direccion = cine.Direccion;
                    findCine.PrecioEntradaGeneral = cine.PrecioEntradaGeneral;
                    findCine.SalaLista = cine.SalaLista;
                    findCine.ProgramacionLista = cine.ProgramacionLista;
                    findCine.HorarioFuncionLista = cine.HorarioFuncionLista;
                }
                return await Task.FromResult(findCine);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
