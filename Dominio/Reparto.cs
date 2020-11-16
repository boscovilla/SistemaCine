using System.Collections.Generic;

namespace Dominio
{
    public class Reparto
    {
        public int RepartoId { get; set; }
        public int ActorId { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
        public ICollection<Actor> Actores { get; set; }
    }
}
