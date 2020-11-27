using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Pelicula
    {
        [Key]
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
        public ICollection<Reparto> RepartoLista { get; set; }
        public ICollection<Funcion> FuncionLista { get; set; }
    }
}
