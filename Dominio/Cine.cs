using System.Collections.Generic;

namespace Dominio
{
    public class Cine
    {
        public int CineId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public float PrecioEntradaGeneral { get; set; }
        public Sala Sala { get; set; }
        public ICollection<Sala> Salas { get; set; }
        public Programacion Programacion { get; set; }
        public int ProgramacionId { get; set; }
        public HorarioFuncion HorarioFuncion { get; set; }
        public int HorarioFuncionId { get; set; }
    }
}
