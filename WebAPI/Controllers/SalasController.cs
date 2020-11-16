
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
    public class SalasController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public SalasController(SistemaCineContext _context)
        {
            this.context = _context;

        }


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
    }
}
