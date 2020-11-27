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
    public class ProgramacionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public ProgramacionesController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        // GET Programaciones
        [HttpGet]
        public IEnumerable<Programacion> Get()
        {
            return context.Programacion.ToList();
        }

        // POST Programacion/Create
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

        // DELETE Programacion/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramacion(int Id)
        {
            var deleteProgramacion = await context.Programacion.FindAsync(Id);
            if (deleteProgramacion == null)
            {
                return NotFound();
            }

            try
            {
                context.Programacion.Remove(deleteProgramacion);
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
        public async Task<Programacion> UpdateProgramacion(int id, [FromBody] Programacion programacion)
        {
            var findProgramacion = await context.Programacion.Where(c => c.ProgramacionId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findProgramacion == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findProgramacion.FechaInicio = programacion.FechaInicio;
                    findProgramacion.FechaFin = programacion.FechaFin;
                    findProgramacion.Funciones = programacion.Funciones;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findProgramacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
