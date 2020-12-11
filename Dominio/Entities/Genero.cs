using System.Collections.Generic;

namespace Dominio.Entities
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Pelicula> Pelicula { get; set; }
    }
}
