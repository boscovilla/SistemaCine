using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Reparto
    {
        public Guid RepartoId { get; set; }
        public Guid ActorId { get; set; }
        public Guid PeliculaId { get; set; }

        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}
