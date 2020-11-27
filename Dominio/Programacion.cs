﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Programacion
    {
        public int ProgramacionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public Funcion Funcion { get; set; }
        public ICollection<Funcion> Funciones { get; set; }
        public Cine Cine { get; set; }
    }
}
