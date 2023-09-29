using Dapper;
using Microsoft.EntityFrameworkCore;
using Multas.Models;
using Npgsql;

namespace Multas.Shared.Services.SParametros
{
    public class ParametroService : IParametroService
    {
        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public ParametroService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }


        public async Task<int> EditParametros(int id, Parametros updateParametro)
        {
            var parametro = await _dbContext.parametros.FindAsync(id);

            if (parametro == null)
            { 
                return 0;
            }
            await _dbContext.SaveChangesAsync();

            return 1; // Indicar que la edición fue exitosa.
        }

        public async Task<List<Parametros>> GetAll()
        {
            var connectionString = GetConnection();
            List<Parametros> parametros = new List<Parametros>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "SELECT * FROM \"Parametros\"";
                    parametros = con.Query<Parametros>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return parametros;
        }

        public Task<int> GetParametroById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
