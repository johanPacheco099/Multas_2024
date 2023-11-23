using Dapper;
using Microsoft.EntityFrameworkCore;
using Multas.Models;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace Multas.Shared.Services.SLiquidacion
{
    public class LiquidacionService : ILiquidacionService
    {

        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public LiquidacionService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<int> Add(Resoluciones resoluciones)
        {
            await _dbContext.resoluciones.AddAsync(resoluciones);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> GenerarAcuerdo(int h, string pcomp, string pcedula, DateTime pfecha, string pvalor, string pinicial, string pinteres, string pvlr_acuerdo, string pcuotas, string pvlr_recibo)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync(); // Utiliza OpenAsync para una operación asincrónica

                    var query = "select from graba_acuerdo('" + pcomp + "','" + pcedula + "','" + pfecha + "', '" + pvalor + "', '" + pinicial + "', '" + pinteres + "', '" + pvlr_acuerdo + "', '" + pcuotas + "', '" + pvlr_recibo + "')";

                    count = await con.ExecuteAsync(query); // Utiliza ExecuteAsync para una operación asincrónica
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }

        public Task<int> GenerarRecibo(int h, string pcomparendo, string pcedula, string pvalor, string pinteres, string pdescuento, string pacuerdo, string precibo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Procesos>> Getcoactivo(string comparendo)
        {
            throw new NotImplementedException();
        }

        public async Task<Liquidaciones> GetComparendo(string compa)
        {
            var connectionString = this.GetConnection();
            Models.Liquidaciones liquidaciones = new Models.Liquidaciones();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM liquidacion('" + compa + "')";
                    liquidaciones = con.Query<Liquidaciones>(query).FirstOrDefault();
                    Console.WriteLine(liquidaciones.pnombre);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return liquidaciones;
            }
        }

        public async Task<List<Recibos>> GetRecibos(string comparendo)
        {
            var connectionString = this.GetConnection();
            List<Recibos> recibos = new List<Recibos>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM recibos WHERE comparendo::varchar = '" + comparendo + "'";
                    recibos = con.Query<Recibos>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return recibos;
            }
        }


        public async Task<List<Resoluciones>> GetResol(string comparendo)
        {
            var connectionString = this.GetConnection();
            List<Resoluciones> resoluciones = new List<Resoluciones>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT n.*,t.nombre as ntipo FROM resoluciones n left join tipos_nov t on (t.id=n.tipo) WHERE n.comparendo::varchar = '" + comparendo + "'";
                    resoluciones = (await con.QueryAsync<Resoluciones>(query)).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return resoluciones;
            }
        }

    }
}
