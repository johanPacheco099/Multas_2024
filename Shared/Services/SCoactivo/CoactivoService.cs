using Dapper;
using Multas.Models;
using Npgsql;

namespace Multas.Shared.Services.SCoactivo
{
    public class CoactivoService : ICoactivoService
    {
        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public CoactivoService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Coactivos>> GetList()
        {
            var connectionString = this.GetConnection();
            List<Coactivos> coactivos = new List<Coactivos>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync(); 
                    var query = "SELECT * FROM sin_coactivo()";
                    coactivos = (await con.QueryAsync<Coactivos>(query)).ToList(); 
                }
                catch (Exception ex)
                {

                    throw new Exception("no se encontraron coactivos");
                }

                return coactivos;
            }
        }

        public async Task<List<Coactivos>> GetList1(string x)
        {
            var connectionString = this.GetConnection();
            List<Coactivos> coactivos = new List<Coactivos>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "SELECT * FROM sin_coactivo()";
                    coactivos = (await con.QueryAsync<Coactivos>(query)).ToList();
                }
                catch (Exception ex)
                {
                    throw; 
                }
                finally
                {
                    con.Close();
                }

                return coactivos;
            }
        }


        public async Task<int> Pasar_coactivo(string id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "select mandamiento(1);";
                    count = (await con.ExecuteAsync(query));
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
    }
}
