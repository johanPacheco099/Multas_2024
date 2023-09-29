using Dapper;
using Microsoft.EntityFrameworkCore;
using Multas.Models;
using Npgsql;

namespace Multas.Shared.Services
{
    public class ComparendoService : IComparendoService
    {
        //dotnet add package Dapper

        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public ComparendoService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<Comparendos> Add(Comparendos comparendos)
        {
            await _dbContext.AddAsync(comparendos);
            await _dbContext.SaveChangesAsync();
            return comparendos;
        }


        public async Task<List<Comparendos>> GetAll()
        {
            var connectionString = GetConnection();
            List<Comparendos> comparendos = new List<Comparendos>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    
                    var query = "SELECT * FROM \"Comparendos\"";
                    comparendos = con.Query<Comparendos>(query).ToList();
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

            return comparendos;

        }

        public Task<Comparendos> UpdateMulta(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteComparendos(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetMultasById(int id)
        {
            var comparendo = await _dbContext.FindAsync<Comparendos>(id);

        }



        public async Task<List<Comparendos>> GetComparendosByCedula(string cedula)
        {
            var connectionString = GetConnection();
            List<Comparendos> comparendosList = new List<Comparendos>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "SELECT * FROM \"Comparendos\" WHERE cedula = @cedula";
                    comparendosList = con.Query<Comparendos>(query, new { cedula }).ToList();
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

            return comparendosList;
        }


    }
}