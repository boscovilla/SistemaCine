using System;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class HorarioFuncion
    {
        [Key]
        public int HorarioFuncionId { get; set; }
        public string DuracionIntervalo { get; set; }
        public string DuracionPublicidad { get; set; }
        [DataType(DataType.Date)]
        public DateTime HoraPrimeraFuncion { get; set; }
        [DataType(DataType.Date)]
        public DateTime HoraUltimaFuncion { get; set; }
        public int CineId { get; set; }
        public Cine Cine { get; set; }
    }
}
