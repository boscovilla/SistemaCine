using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        public string TipoGenero { get; set; }
        public string Descripcion { get; set; }
        public Pelicula Pelicula { get; set; }
        public int PeliculaId { get; set; }
    }
}
