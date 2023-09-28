using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Tarifas
    {
        [Required]
        [Key]
        public int id { get; set; }
        public int vigencia { get; set; }
        public float salario { get; set; }
        public int usuario { get; set; }
        public string equipo { get; set; }

    }
}
