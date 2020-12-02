using Dominio;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public PeliculasController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<Pelicula> Get()
        {
            return context.Pelicula.ToList();
        }
    }
}
