using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Genero
    {
        public Guid GeneroId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Pelicula> Pelicula { get; set; }
    }
}
