
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
    public class RepartosController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public RepartosController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<Reparto> Get()
        {
            return context.Reparto.ToList();
        }

        //POST. Repartos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReparto(Reparto createReparto)
        {

            context.Reparto.Add(createReparto);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get),
                new Reparto { RepartoId = createReparto.RepartoId },
                createReparto);



        }
    }
}
