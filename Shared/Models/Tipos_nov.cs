using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Tipos_nov
    {
        [Required]
        [Key]
        public int id { get; set; }
        [StringLength(30)]
        [Required]
        public string nombre { get; set; }

        public int codigo_simit { get; set; }

        public bool resol_ant { get; set; }

        public bool resol_igual { get; set; }
    }
}
