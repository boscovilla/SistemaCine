using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
   public class Cine
    {
        public Guid CineId { get; set; }

        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public float PrecioEntradaGeneral { get; set; }

        public ICollection<Sala> SalaLista { get; set; }
        public ICollection<Programacion> ProgramacionLista { get; set; }
        public ICollection<HorarioFuncion> HorarioFuncionLista { get; set; }
    }
}
