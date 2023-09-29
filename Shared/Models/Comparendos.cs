using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Multas.Models
{
    public class Comparendos
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        public string comparendo { get; set; }
        [Required]
        public string cedula { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        public TimeOnly hora { get; set; }
        public string lugar { get; set; }
        [Required]
        public int clase_veh { get; set; }
        [Required]
        public string infraccion { get; set; }
        public string lic_tran { get; set; }
        public string targ_oper { get; set; }
        public string gsangre { get; set; }
        public string? obs { get; set; }
        public bool inmovil { get; set; }
        [Required]
        public int estado { get; set; }
        public int tipo_servicio { get; set; }
        public int entidad { get; set; }
        public int categoria { get; set; }
        public string placa { get; set; }
        public double valor { get; set; }
        public double abono { get; set; }
        public double descuento { get; set; }
        public int tipo_id { get; set; }
        public string resol { get; set; }
        public string lic_con { get; set; }
        [Required]
        public string agente { get; set; }
        public bool fuga { get; set; }
        public bool accidente { get; set; }
        public int tipo_infractor { get; set; }
        public bool sancionado { get; set; }
        public bool importado { get; set; }
        public double vlr_acuerdo { get; set; }
        public int patio { get; set; }
        public string prueba { get; set; }

        public int codigo_tran { get; set; }
        public int modal_tran { get; set; }
        public string grua { get; set; }
        public string placa_grua { get; set; }
        public int tipo_id_prop { get; set; }
        public string cedula_prop { get; set; }
        public int radio_accion { get; set; }
        public string divipo_placa { get; set; }
        public string id_testigo { get; set; }
        public bool incumplio { get; set; }
        public int grado_alcol { get; set; }
        public string equipo { get; set; }
        public bool fotomulta { get; set; }
        public DateTime fecha_notif { get; set; }
        public DateTime fec_Sancion { get; set; }
        public int vel_per { get; set; }
        public int vel_medida { get; set; }
        public int mun { get; set; }
    }
}
