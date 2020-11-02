using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Reparto
    {
        public int RepartoId { get; set; }
        public int ActorId { get; set; }
        public int PeliculaId { get; set; }

        public Pelicula Pelicula { get; set; }
        public Actor Actor { get; set; }
    }
}
