using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int id { get; set; }
        public string login { get; set; }
        public string nombre { get; set; }
        public bool habilitado { get; set; }
        public string clave { get; set; }
        public int nivel { get; set; }
        public bool cajero { get; set; }
        public bool inspector { get; set; }
        public string dir { get; set; }
        public string tel { get; set; }
        public string correo { get; set; }
        public int banco { get; set; }
        public int usuario_creo { get; set; }
    }
}
