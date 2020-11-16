
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
    public class FuncionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public FuncionesController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<Funcion> Get()
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
            return CreatedAtAction(nameof(Get),
                new Funcion { FuncionId = createFuncion.FuncionId },
                createFuncion);



        }
    }
}
