﻿using Dominio;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinesController : ControllerBase
    {
        private readonly SistemaCineContext context;
        public CinesController(SistemaCineContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<Cine> Get()
        {
            return context.Cine.ToList();
        }
    }
}
