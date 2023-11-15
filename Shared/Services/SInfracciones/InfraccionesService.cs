using Microsoft.EntityFrameworkCore;
using Multas.Models;
using Multas.Pages.PInfracciones;
using Infracciones = Multas.Models.Infracciones;
using Npgsql;
using Dapper;

namespace Multas.Shared.Services.SInfracciones
{
    public class InfraccionesService : IInfraccionesService
    {
        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public InfraccionesService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<string> GetNameInfraccionByCode(string code)
        {
            var connectionString = GetConnection();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();

                    // Consulta para obtener el nombre de la infracción por código
                    var query = "SELECT nombre FROM \"infracciones\" WHERE codigo = @codigo";

                    // Utilizamos QueryFirstOrDefaultAsync para obtener un solo resultado
                    var nombreInfraccion = await con.QueryFirstOrDefaultAsync<string>(query, new { codigo = code });

                    // Devolver el nombre de la infracción
                    return nombreInfraccion;
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
        }

    }
}
