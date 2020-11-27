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
    public class FuncionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public FuncionesController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        // GET Funciones
        [HttpGet]
        public IEnumerable<Funcion> GetFunciones()
        {
            return context.Funcion.ToList();
        }

        //POST. Funcion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFuncion(Funcion createFuncion)
        {
            context.Funcion.Add(createFuncion);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFunciones),
                new Funcion { FuncionId = createFuncion.FuncionId },
                createFuncion);
        }

        // DELETE: Funcion/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncion(int Id)
        {
            var deleteFuncion = await context.Funcion.FindAsync(Id);
            if (deleteFuncion == null)
            {
                return NotFound();
            }

            try
            {
                context.Funcion.Remove(deleteFuncion);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception err)
            {
                return (IActionResult)err;
            }
        }

        // PUT: Funcion/id
        [HttpPut("{id}")]
        public async Task<Funcion> UpdateFuncion(int id, [FromBody] Funcion funcion)
        {
            var findFuncion = await context.Funcion.Where(c => c.FuncionId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findFuncion == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findFuncion.DiaSemana = funcion.DiaSemana;
                    findFuncion.HoraInicio = funcion.HoraInicio;
                    findFuncion.Duracion = funcion.Duracion;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findFuncion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
