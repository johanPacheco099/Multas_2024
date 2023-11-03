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
            try
            {
                // Intenta agregar el objeto comparendos a la base de datos
                var ok = await _dbContext.AddAsync(comparendos);

                if (ok != null)
                {
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    // Lanza una excepción con un mensaje de error personalizado
                    throw new InvalidOperationException("No se pudo agregar el comparendo. Mensaje de error personalizado.");
                }
            }
            catch (Exception ex)
            {
                // Lanza una excepción con el mensaje de error original
                throw new Exception("Error al agregar el comparendo: " + ex.Message);
            }

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

                    var query = "SELECT * FROM \"comparendos\"";
                    comparendos = con.Query<Comparendos>(query).ToList();
                }
                catch (NpgsqlException ex)
                {
                    // Aquí puedes realizar acciones adicionales, como registrar el error en un archivo de registro
                    // o mostrar un mensaje de error más descriptivo al usuario.
                    Console.WriteLine("Ocurrió un error al obtener los comparendos: " + ex.Message);

                    // También puedes lanzar una nueva excepción personalizada si lo deseas.
                    throw new Exception("Error al obtener los comparendos", ex);
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
                    var query = "SELECT * FROM \"comparendos\" WHERE cedula = @cedula";
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