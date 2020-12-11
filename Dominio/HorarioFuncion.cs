﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio
{
    public class HorarioFuncion
    {

        public Guid HorarioFuncionId { get; set; }

        
        public string DuracionIntervalo { get; set; }

       
        public string DuracionPublicidad { get; set; }

        [DataType(DataType.Date)]
        public DateTime HoraPrimeraFuncion { get; set; }
        [DataType(DataType.Date)]
        public DateTime HoraUltimaFuncion { get; set; }

        public Guid CineId { get; set; }

        public Cine Cine { get; set; }


    }
}
