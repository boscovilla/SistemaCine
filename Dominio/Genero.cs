using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        public string TipoGenero { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Pelicula> Pelicula { get; set; }
    }
}
