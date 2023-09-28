using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Recibos
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public int estado { get; set; }
        public string cedula { get; set; }
        public double valor { get; set; }
        public double interes_mora { get; set; }
        public double descuento { get; set; }
        public double vlrrecibo { get; set; }
        public string comparendo { get; set; }
        public DateTime fecpago { get; set; }
        public int fpago { get; set; }
        public string cheque { get; set; }
        public int usuario { get; set; }
        public int banco { get; set; }
        public int tipo_id { get; set; }
        public DateTime fecha_proceso { get; set; }
        public DateTime fecha_aplica { get; set; }
        public char tipo { get; set; }
        public double vlr_adicional { get; set; }
        public int user_liq { get; set; }
        public string equipo_pago { get; set; }
        public double titulo_valor { get; set; }
        public int decuota { get; set; }
        public int acuota { get; set; }
        public int nfinancia { get; set; }

    }
}
