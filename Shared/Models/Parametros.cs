using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Parametros
    {
        [Key]
        [Required]
        public int id { get; set; }

        public string nit { get; set; }
        public string dir { get; set; }
        public string tel { get; set; }
        public string divipo { get; set; }
        public string ciudad { get; set; }
        [Required]
        public string nombre { get; set; }

        public DateTime fec_ini_interes { get; set; }

        public double vlr_recibo { get; set; }

        public string correo { get; set; }
        public bool incumplio { get; set; }
        public int cuotas_finan { get; set; }

        public int tipo_acuerdo { get; set; }

        public int dh_fecha1 { get; set; }
        public int dh_fecha2 { get; set; }
        public int dh_fecha3 { get; set; }
        public int dh_fecha4 { get; set; }
        public int dh_fecha5 { get; set; }
        public int dh_fecha6 { get; set; }
        public DateTime fecha_Nueva_ley { get; set; }
        public DateTime fin_nueva_ley { get; set; }
        public double porc_min_fin { get; set; }
        public int tipo_inicial { get; set; }
        public int min_inactivo { get; set; }

        public bool susp_lic { get; set; }

        public bool bloquea_hora { get; set; }

        public bool cobra_adicional { get; set; }

        public bool coactivo_man { get; set; }

        public bool costas { get; set; }
        public int dias_persuasivo { get; set; }
        public int dias_coactivo { get; set; }

        public int dias_mdto { get; set; }

    }
}
