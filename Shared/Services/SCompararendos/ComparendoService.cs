using Dapper;
using Microsoft.EntityFrameworkCore;
using Multas.Models;
using Multas.Pages.PInfracciones;
using Multas.Pages.PParametros;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Infracciones = Multas.Models.Infracciones;

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

        public async Task<Comparendos> UpdateMulta(int id, Comparendos updatedComparendo)
        {
            var existingComparendo = await _dbContext.comparendos.FirstOrDefaultAsync(c => c.id == id);

            if (existingComparendo != null)
            {
                // Aquí actualizas los campos del comparendo existente con los valores del comparendo actualizado.
                existingComparendo.comparendo = updatedComparendo.comparendo;
                existingComparendo.fecha = updatedComparendo.fecha;
                existingComparendo.hora = updatedComparendo.hora;
                existingComparendo.cedula = updatedComparendo.cedula;
                existingComparendo.infraccion = updatedComparendo.infraccion;
                existingComparendo.valor = updatedComparendo.valor;

                await _dbContext.SaveChangesAsync();

                return existingComparendo;
            }
            else
            {
                throw new FileNotFoundException($"Comparendo con ID {id} no encontrado.");
            }
        }


        public int DeleteComparendos(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Comparendos> GetMultasById(int id)
        {
            try
            {
                var comparendo = await _dbContext.FindAsync<Comparendos>(id);
                return comparendo;

            }
            catch (Exception)
            {

                throw;
            }
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



        public async Task<double> calculoUvts(DateTime pfecha, string pinfraccion, int pgrado, int preincide)
        {
            try
            {
                var connectionString = GetConnection();

                using var connection = new NpgsqlConnection(connectionString);
                await connection.OpenAsync();

                var cmd = new NpgsqlCommand();
                cmd.CommandText = "SELECT public.calc_inf(@pfecha, @infrac, @pgrado, @preincide)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;

                // Configura los parámetros
                cmd.Parameters.Add(new NpgsqlParameter("@pfecha", NpgsqlDbType.Date) { Value = pfecha });
                cmd.Parameters.Add(new NpgsqlParameter("@infrac", NpgsqlDbType.Text) { Value = pinfraccion });
                cmd.Parameters.Add(new NpgsqlParameter("@pgrado", NpgsqlDbType.Integer) { Value = pgrado });
                cmd.Parameters.Add(new NpgsqlParameter("@preincide", NpgsqlDbType.Integer) { Value = preincide });

                // Utiliza ExecuteScalarAsync para obtener el valor de retorno
                var result = await cmd.ExecuteScalarAsync();

                if (result != null && result != DBNull.Value)
                {
                    // Convierte el resultado a double
                    if (double.TryParse(result.ToString(), out double doubleValue))
                    {
                        Console.WriteLine($"Valor de retorno (double): {doubleValue}");
                        return doubleValue;
                    }
                    else
                    {
                        Console.WriteLine("Error al convertir el resultado a double");
                    }
                }
                else
                {
                    Console.WriteLine("El resultado es nulo o DBNull");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Puedes manejar el error según tus necesidades, por ejemplo, lanzar una excepción o devolver un valor predeterminado.
            }

            // Si hay un error, retorna un valor predeterminado o 0.0 según tus necesidades.
            return 0.0;
        }

        
    }
}

