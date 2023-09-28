using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Sanciones
    {

        public int id { get; set; }
        public string comparendo { get; set; }
        public string cedula { get; set; }
        public DateTime fecha { get; set; }

        public DateTime fecha_san { get; set; }

        public double valor { get; set; }
    }
}
