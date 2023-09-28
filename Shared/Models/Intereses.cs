using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Intereses
    {
        [Required]
        [Key]
        public int id { get; set; }
        public int mes { get; set; }
        public float porc { get; set; }
        public DateTime indesde { get; set; }
        public DateTime inhasta { get; set; }
        [Required]
        public int vigencia { get; set; }

    }
}
