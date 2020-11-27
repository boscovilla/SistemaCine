using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalasController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public SalasController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        // GET Salas
        [HttpGet]
        public IEnumerable<Sala> Get()
        {
            return context.Sala.ToList();
        }

        //POST. Salas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSala(Sala createSala)
        {
            context.Sala.Add(createSala);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new Sala { SalaId = createSala.SalaId },
                createSala);
        }

        // DELETE: Sala/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int Id)
        {
            var deleteSala = await context.Sala.FindAsync(Id);
            if (deleteSala == null)
            {
                return NotFound();
            }

            try
            {
                context.Sala.Remove(deleteSala);
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
        public async Task<Sala> UpdateActor(int id, [FromBody] Sala sala)
        {
            var findSala = await context.Sala.Where(c => c.SalaId == id)
                .FirstOrDefaultAsync();
            try
            {
                if (findSala == null)
                {
                    throw new SystemException();
                }
                else
                {
                    findSala.Capacidad = sala.Capacidad;
                    findSala.Numero = sala.Numero;
                    findSala.FuncionLista = sala.FuncionLista;
                    await context.SaveChangesAsync();
                }
                return await Task.FromResult(findSala);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
