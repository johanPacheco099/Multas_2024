using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Infracciones
    {
        [Required]
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public double valor { get; set; }
        public bool descuento { get; set; }
        public bool simit { get; set; }
        public string simitCod { get; set; }
        public bool inmovil { get; set; }
        public string homologar { get; set; }
        public bool supervisor { get; set; }
        public bool activa { get; set; }
        public bool alerta { get; set; }
        public int reincidencias { get; set; }
        public bool alcohol { get; set; }
        public int grupo { get; set; }
        //public DateTime FechaProceso { get; set; }
        public string usuario { get; set; }
        public string equipo { get; set; }
    }
}
