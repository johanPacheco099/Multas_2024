using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Liquidaciones
    {
        [Required]
        [Key]
        public int id { get; set; }
        public DateTime pfecha { get; set; }
        public TimeSpan Phora { get; set; }
        public string pinfraccion { get; set; }
        public string pninfraccion { get; set; }
        public string pdoc { get; set; }
        public string pnombre { get; set; }
        public double pvalor { get; set; }
        public double pdescuento { get; set; }
        public double pabono { get; set; }
        public double pinteres_mora { get; set; }
        public string pestado { get; set; }
        public bool psancionado { get; set; }
        public string presol { get; set; }
        public string pplaca { get; set; }
        public string comparendo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double pvlr_recibo { get; set; }
        public double pvlr_adicional { get; set; }
        public double porc_ac { get; set; }
        public double ptotal { get; set; }

        public int tipo_in { get; set; }
        public double vlr_inicial { get; set; }
    }
}
