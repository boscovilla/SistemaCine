﻿using System.Collections.Generic;

namespace Dominio
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nacionalidad { get; set; }
        public ICollection<Reparto> RepartoLista { get; set; }
    }
}
