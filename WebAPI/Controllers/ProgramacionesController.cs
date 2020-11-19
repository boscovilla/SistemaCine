
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
    public class ProgramacionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public ProgramacionesController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<Programacion> Get()
        {
            return context.Programacion.ToList();
        }

        //POST. Programaciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateActor(Programacion createProgramacion)
        {

            context.Programacion.Add(createProgramacion);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new Programacion { ProgramacionId = createProgramacion.ProgramacionId },
                createProgramacion);



        }

        // DELETE: Programaciones/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteProgramacion(int ProgramacionId)
        {
            var deleteProgramacion = await context.Programacion.FindAsync(ProgramacionId);
            if (deleteProgramacion == null)
            {
                return NotFound();
            }

            context.Programacion.Remove(deleteProgramacion);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
