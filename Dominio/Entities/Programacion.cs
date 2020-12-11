using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities
{
    public class Programacion
    {
        public Guid ProgramacionId { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        public ICollection<Funcion> FuncionLista { get; set; }
        public Cine Cine { get; set; }
    }
}
