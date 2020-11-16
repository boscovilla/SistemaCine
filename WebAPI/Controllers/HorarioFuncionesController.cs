
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
    public class HorariosFuncionesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public HorariosFuncionesController(SistemaCineContext _context)
        {
            this.context = _context;

        }


        [HttpGet]

        public IEnumerable<HorarioFuncion> Get()
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
            return CreatedAtAction(nameof(Get),
                new HorarioFuncion { HorarioFuncionId = createHorario.HorarioFuncionId },
                createHorario);



        }
    }
}
