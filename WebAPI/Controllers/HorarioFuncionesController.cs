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
    public class HorariosFuncionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public HorariosFuncionesController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        // GET Horarios
        [HttpGet]
        public IEnumerable<HorarioFuncion> GetHorario()
        {
            return context.HorarioFuncion.ToList();
        }

        //POST. Horario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHorarioFuncion(HorarioFuncion createHorario)
        {
            context.HorarioFuncion.Add(createHorario);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHorario),
                new HorarioFuncion { HorarioFuncionId = createHorario.HorarioFuncionId },
                createHorario);
        }

        // DELETE: Actor/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorario(int Id)
        {
            var deleteHorario = await context.HorarioFuncion.FindAsync(Id);
            if (deleteHorario == null)
            {
                return NotFound();
            }

            try
            {
                context.HorarioFuncion.Remove(deleteHorario);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // PUT: HorarioFuncion/id
        [HttpPut("{id}")]
        public async Task<HorarioFuncion> UpdateHorario(int id, [FromBody] HorarioFuncion horario)
        {
            var findHorario = await context.HorarioFuncion.Where(c => c.HorarioFuncionId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findHorario == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findHorario.DuracionIntervalo = horario.DuracionIntervalo;
                    findHorario.DuracionPublicidad = horario.DuracionPublicidad;
                    findHorario.HoraPrimeraFuncion = horario.HoraPrimeraFuncion;
                    findHorario.HoraUltimaFuncion = horario.HoraUltimaFuncion;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findHorario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
