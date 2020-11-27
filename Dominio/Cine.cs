using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Cine
    {
        [Key]
        public int CineId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public float PrecioEntradaGeneral { get; set; }
        public ICollection<Sala> SalaLista { get; set; }
        public ICollection<Programacion> ProgramacionLista { get; set; }
        public ICollection<HorarioFuncion> HorarioFuncionLista { get; set; }
    }
}
