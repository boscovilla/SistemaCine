using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Nombre { get; set; }
        public string Duracion { get; set; }
        public string Sinopsis { get; set; }
        public string Director { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEstreno { get; set; }
        public string Categoria { get; set; }
        public bool Disponible { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
        public Reparto Reparto { get; set; }
        public int RepartoId { get; set; }
        public Funcion Funcion { get; set; }
        public ICollection<Funcion> Funciones { get; set; }
    }
}
