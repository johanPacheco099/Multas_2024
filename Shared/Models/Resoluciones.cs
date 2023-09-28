using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Resoluciones
    {
        [Key]
        public int id { get; set; }
        public string comparendo { get; set; }
        public string resolucion { get; set; }

        public int tipo { get; set; }

        public DateTime fecha { get; set; }
        public double valor { get; set; }
        public string estado { get; set; }
        public string resol_ant { get; set; }
        public string ntipo { get; set; }


    }
}
