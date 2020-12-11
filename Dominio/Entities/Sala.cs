using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Sala
    {
        public int SalaId { get; set; }
        public int Capacidad { get; set; }
        public string Numero { get; set; }
        public string CineId { get; set; }
        public Cine Cine { get; set; }
        public ICollection<Funcion> FuncionLista { get; set; }
    }
}
