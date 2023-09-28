using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Multas.Migrations
{
    /// <inheritdoc />
    public partial class Postgres01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coactivos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comparendo = table.Column<string>(type: "text", nullable: true),
                    cedula = table.Column<string>(type: "text", nullable: true),
                    infraccion = table.Column<string>(type: "text", nullable: true),
                    fecha_comp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_sancion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_mdto = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_proceso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coactivos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comparendos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comparendo = table.Column<string>(type: "text", nullable: false),
                    cedula = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hora = table.Column<TimeSpan>(type: "interval", nullable: false),
                    lugar = table.Column<string>(type: "text", nullable: false),
                    clase_veh = table.Column<int>(type: "integer", nullable: false),
                    infraccion = table.Column<string>(type: "text", nullable: false),
                    lic_tran = table.Column<string>(type: "text", nullable: false),
                    targ_oper = table.Column<string>(type: "text", nullable: false),
                    gsangre = table.Column<string>(type: "text", nullable: false),
                    obs = table.Column<string>(type: "text", nullable: true),
                    inmovil = table.Column<bool>(type: "boolean", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    tipo_servicio = table.Column<int>(type: "integer", nullable: false),
                    entidad = table.Column<int>(type: "integer", nullable: false),
                    categoria = table.Column<int>(type: "integer", nullable: false),
                    placa = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    abono = table.Column<double>(type: "double precision", nullable: false),
                    descuento = table.Column<double>(type: "double precision", nullable: false),
                    tipo_id = table.Column<int>(type: "integer", nullable: false),
                    resol = table.Column<string>(type: "text", nullable: false),
                    lic_con = table.Column<string>(type: "text", nullable: false),
                    agente = table.Column<string>(type: "text", nullable: false),
                    fuga = table.Column<bool>(type: "boolean", nullable: false),
                    accidente = table.Column<bool>(type: "boolean", nullable: false),
                    tipo_infractor = table.Column<int>(type: "integer", nullable: false),
                    sancionado = table.Column<bool>(type: "boolean", nullable: false),
                    importado = table.Column<bool>(type: "boolean", nullable: false),
                    vlr_acuerdo = table.Column<double>(type: "double precision", nullable: false),
                    patio = table.Column<int>(type: "integer", nullable: false),
                    prueba = table.Column<string>(type: "text", nullable: false),
                    codigo_tran = table.Column<int>(type: "integer", nullable: false),
                    modal_tran = table.Column<int>(type: "integer", nullable: false),
                    grua = table.Column<string>(type: "text", nullable: false),
                    placa_grua = table.Column<string>(type: "text", nullable: false),
                    tipo_id_prop = table.Column<int>(type: "integer", nullable: false),
                    cedula_prop = table.Column<string>(type: "text", nullable: false),
                    radio_accion = table.Column<int>(type: "integer", nullable: false),
                    divipo_placa = table.Column<string>(type: "text", nullable: false),
                    id_testigo = table.Column<string>(type: "text", nullable: false),
                    incumplio = table.Column<bool>(type: "boolean", nullable: false),
                    grado_alcol = table.Column<int>(type: "integer", nullable: false),
                    equipo = table.Column<string>(type: "text", nullable: false),
                    fotomulta = table.Column<bool>(type: "boolean", nullable: false),
                    fecha_notif = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fec_Sancion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vel_per = table.Column<int>(type: "integer", nullable: false),
                    vel_medida = table.Column<int>(type: "integer", nullable: false),
                    mun = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comparendos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "infracciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    descuento = table.Column<bool>(type: "boolean", nullable: false),
                    simit = table.Column<bool>(type: "boolean", nullable: false),
                    simitCod = table.Column<string>(type: "text", nullable: false),
                    inmovil = table.Column<bool>(type: "boolean", nullable: false),
                    homologar = table.Column<string>(type: "text", nullable: false),
                    supervisor = table.Column<bool>(type: "boolean", nullable: false),
                    activa = table.Column<bool>(type: "boolean", nullable: false),
                    alerta = table.Column<bool>(type: "boolean", nullable: false),
                    reincidencias = table.Column<int>(type: "integer", nullable: false),
                    alcohol = table.Column<bool>(type: "boolean", nullable: false),
                    grupo = table.Column<int>(type: "integer", nullable: false),
                    usuario = table.Column<string>(type: "text", nullable: false),
                    equipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infracciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "infractores",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    cedula = table.Column<string>(type: "text", nullable: false),
                    tipo_ident = table.Column<int>(type: "integer", nullable: false),
                    nombre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    apellidos = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    direccion = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    tel = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ciudad = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    correo = table.Column<string>(type: "text", nullable: false),
                    licencia = table.Column<string>(type: "text", nullable: false),
                    ciudad_lic = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    categoria = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infractores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "intereses",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mes = table.Column<int>(type: "integer", nullable: false),
                    porc = table.Column<float>(type: "real", nullable: false),
                    indesde = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    inhasta = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vigencia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intereses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "liquidaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pfecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Phora = table.Column<TimeSpan>(type: "interval", nullable: false),
                    pinfraccion = table.Column<string>(type: "text", nullable: false),
                    pninfraccion = table.Column<string>(type: "text", nullable: false),
                    pdoc = table.Column<string>(type: "text", nullable: false),
                    pnombre = table.Column<string>(type: "text", nullable: false),
                    pvalor = table.Column<double>(type: "double precision", nullable: false),
                    pdescuento = table.Column<double>(type: "double precision", nullable: false),
                    pabono = table.Column<double>(type: "double precision", nullable: false),
                    pinteres_mora = table.Column<double>(type: "double precision", nullable: false),
                    pestado = table.Column<string>(type: "text", nullable: false),
                    psancionado = table.Column<bool>(type: "boolean", nullable: false),
                    presol = table.Column<string>(type: "text", nullable: false),
                    pplaca = table.Column<string>(type: "text", nullable: false),
                    comparendo = table.Column<string>(type: "text", nullable: false),
                    pvlr_recibo = table.Column<double>(type: "numeric(18,2)", nullable: false),
                    pvlr_adicional = table.Column<double>(type: "double precision", nullable: false),
                    porc_ac = table.Column<double>(type: "double precision", nullable: false),
                    ptotal = table.Column<double>(type: "double precision", nullable: false),
                    tipo_in = table.Column<int>(type: "integer", nullable: false),
                    vlr_inicial = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_liquidaciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "parametros",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nit = table.Column<string>(type: "text", nullable: false),
                    dir = table.Column<string>(type: "text", nullable: false),
                    tel = table.Column<string>(type: "text", nullable: false),
                    divipo = table.Column<string>(type: "text", nullable: false),
                    ciudad = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    fec_ini_interes = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    vlr_recibo = table.Column<double>(type: "double precision", nullable: false),
                    correo = table.Column<string>(type: "text", nullable: false),
                    incumplio = table.Column<bool>(type: "boolean", nullable: false),
                    cuotas_finan = table.Column<int>(type: "integer", nullable: false),
                    tipo_acuerdo = table.Column<int>(type: "integer", nullable: false),
                    dh_fecha1 = table.Column<int>(type: "integer", nullable: false),
                    dh_fecha2 = table.Column<int>(type: "integer", nullable: false),
                    dh_fecha3 = table.Column<int>(type: "integer", nullable: false),
                    dh_fecha4 = table.Column<int>(type: "integer", nullable: false),
                    dh_fecha5 = table.Column<int>(type: "integer", nullable: false),
                    dh_fecha6 = table.Column<int>(type: "integer", nullable: false),
                    fecha_Nueva_ley = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fin_nueva_ley = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    porc_min_fin = table.Column<double>(type: "double precision", nullable: false),
                    tipo_inicial = table.Column<int>(type: "integer", nullable: false),
                    min_inactivo = table.Column<int>(type: "integer", nullable: false),
                    susp_lic = table.Column<bool>(type: "boolean", nullable: false),
                    bloquea_hora = table.Column<bool>(type: "boolean", nullable: false),
                    cobra_adicional = table.Column<bool>(type: "boolean", nullable: false),
                    coactivo_man = table.Column<bool>(type: "boolean", nullable: false),
                    costas = table.Column<bool>(type: "boolean", nullable: false),
                    dias_persuasivo = table.Column<int>(type: "integer", nullable: false),
                    dias_coactivo = table.Column<int>(type: "integer", nullable: false),
                    dias_mdto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parametros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persuasivos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comparendo = table.Column<string>(type: "text", nullable: false),
                    cedula = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    nombres = table.Column<string>(type: "text", nullable: false),
                    infraccion = table.Column<string>(type: "text", nullable: false),
                    dir = table.Column<string>(type: "text", nullable: false),
                    tel = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    ciudad = table.Column<string>(type: "text", nullable: false),
                    fecven = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dpto = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persuasivos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "procesos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comparendo = table.Column<string>(type: "text", nullable: false),
                    fecha_mdto = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    nestado = table.Column<string>(type: "text", nullable: false),
                    resolucion = table.Column<string>(type: "text", nullable: false),
                    expediente = table.Column<string>(type: "text", nullable: false),
                    fecha_proc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procesos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recibos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    estado = table.Column<int>(type: "integer", nullable: false),
                    cedula = table.Column<string>(type: "text", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    interes_mora = table.Column<double>(type: "double precision", nullable: false),
                    descuento = table.Column<double>(type: "double precision", nullable: false),
                    vlrrecibo = table.Column<double>(type: "double precision", nullable: false),
                    comparendo = table.Column<string>(type: "text", nullable: false),
                    fecpago = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fpago = table.Column<int>(type: "integer", nullable: false),
                    cheque = table.Column<string>(type: "text", nullable: false),
                    usuario = table.Column<int>(type: "integer", nullable: false),
                    banco = table.Column<int>(type: "integer", nullable: false),
                    tipo_id = table.Column<int>(type: "integer", nullable: false),
                    fecha_proceso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_aplica = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tipo = table.Column<char>(type: "character(1)", nullable: false),
                    vlr_adicional = table.Column<double>(type: "double precision", nullable: false),
                    user_liq = table.Column<int>(type: "integer", nullable: false),
                    equipo_pago = table.Column<string>(type: "text", nullable: false),
                    titulo_valor = table.Column<double>(type: "double precision", nullable: false),
                    decuota = table.Column<int>(type: "integer", nullable: false),
                    acuota = table.Column<int>(type: "integer", nullable: false),
                    nfinancia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recibos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "resoluciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comparendo = table.Column<string>(type: "text", nullable: false),
                    resolucion = table.Column<string>(type: "text", nullable: false),
                    tipo = table.Column<int>(type: "integer", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false),
                    estado = table.Column<string>(type: "text", nullable: false),
                    resol_ant = table.Column<string>(type: "text", nullable: false),
                    ntipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resoluciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sanciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comparendo = table.Column<string>(type: "text", nullable: false),
                    cedula = table.Column<string>(type: "text", nullable: false),
                    fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_san = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    valor = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanciones", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tarifas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    vigencia = table.Column<int>(type: "integer", nullable: false),
                    salario = table.Column<float>(type: "real", nullable: false),
                    usuario = table.Column<int>(type: "integer", nullable: false),
                    equipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarifas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_nov",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    codigo_simit = table.Column<int>(type: "integer", nullable: false),
                    resol_ant = table.Column<bool>(type: "boolean", nullable: false),
                    resol_igual = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_nov", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: false),
                    nombre = table.Column<string>(type: "text", nullable: false),
                    habilitado = table.Column<bool>(type: "boolean", nullable: false),
                    clave = table.Column<string>(type: "text", nullable: false),
                    nivel = table.Column<int>(type: "integer", nullable: false),
                    cajero = table.Column<bool>(type: "boolean", nullable: false),
                    inspector = table.Column<bool>(type: "boolean", nullable: false),
                    dir = table.Column<string>(type: "text", nullable: false),
                    tel = table.Column<string>(type: "text", nullable: false),
                    correo = table.Column<string>(type: "text", nullable: false),
                    banco = table.Column<int>(type: "integer", nullable: false),
                    usuario_creo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coactivos");

            migrationBuilder.DropTable(
                name: "Comparendos");

            migrationBuilder.DropTable(
                name: "infracciones");

            migrationBuilder.DropTable(
                name: "infractores");

            migrationBuilder.DropTable(
                name: "intereses");

            migrationBuilder.DropTable(
                name: "liquidaciones");

            migrationBuilder.DropTable(
                name: "parametros");

            migrationBuilder.DropTable(
                name: "persuasivos");

            migrationBuilder.DropTable(
                name: "procesos");

            migrationBuilder.DropTable(
                name: "recibos");

            migrationBuilder.DropTable(
                name: "resoluciones");

            migrationBuilder.DropTable(
                name: "sanciones");

            migrationBuilder.DropTable(
                name: "tarifas");

            migrationBuilder.DropTable(
                name: "tipos_nov");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
