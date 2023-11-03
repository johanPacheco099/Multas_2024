using Dapper;
using Multas.Models;
using Npgsql;

namespace Multas.Shared.Services.SSanciones
{
    public class SancionService : ISancionService
    {
        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public SancionService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Sanciones>> GetAll()
        {
            var connectionString = this.GetConnection();
            List<Sanciones> sanciones = new List<Sanciones>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    //var query = "select sancionar(" + id + ");";
                    var query = "SELECT * FROM sin_sancion('1')";
                    sanciones = (await con.QueryAsync<Sanciones>(query)).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return sanciones;
            }
        }

        public Task<int> Sancionar(string id)
        {
            throw new NotImplementedException();
        }
    }
}
