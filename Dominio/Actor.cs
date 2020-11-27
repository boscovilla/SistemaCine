using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
        public int Edad { get; set; }
        public ICollection<Reparto> RepartoLista { get; set; }
    }
}
