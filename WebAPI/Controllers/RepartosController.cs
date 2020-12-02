﻿using Dominio;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Collections.Generic;
using System.Linq;

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
    }
}
