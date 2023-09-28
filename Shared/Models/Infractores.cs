using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Multas.Models
{
    public class Infractores
    {
        [Required]
        [Key]
        public string id { get; set; }
        [Required]
        public string cedula { get; set; }
        [Required]
        public int tipo_ident { get; set; }
        [StringLength(30)]
        public string nombre { get; set; }
        [StringLength(30)]
        public string apellidos { get; set; }
        [StringLength(45)]
        public string direccion { get; set; }
        [StringLength(15)]
        public string tel { get; set; }
        [Required]
        [StringLength(8)]
        public string ciudad { get; set; }
        public string correo { get; set; }
        public string licencia { get; set; }
        [StringLength(8)]
        public string ciudad_lic { get; set; }
        public string categoria { get; set; }
    }
}
