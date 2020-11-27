using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Funcion
    {
        [Key]
        public int FuncionId { get; set; }
        public string DiaSemana { get; set; }
        public string HoraInicio { get; set; }
        public string Duracion { get; set; }
        public int PeliculaId { get; set; }
        public int ProgramacionId { get; set; }
        public int SalaId { get; set; }
        public Programacion Programacion { get; set; }
        public Pelicula Pelicula { get; set; }
        public Sala Sala { get; set; }
    }
}
