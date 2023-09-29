using Dapper;
using Multas.Models;
using Npgsql;

namespace Multas.Shared.Services.SUser
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public UserService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public string GetConnection()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> AddUser(Usuario usuarios)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "INSERT INTO infractores(cedula,tipo_ident,nombre,direccion,tel,licencia,ciudad,correo,apellidos,categoria,ciudad_lic) VALUES(@cedula,@tipo_ident,@nombre,@direccion,@tel,@licencia,@ciudad,@correo,@apellidos,@categoria,@ciudad_lic);";
                    count = (await con.ExecuteAsync(query, usuarios));

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

        public async Task<int> DeleteUsuarioById(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "DELETE FROM infractores WHERE id =" + id;
                    count = ( await con.ExecuteAsync(query));
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
        public async Task<int> UpdateUser(Usuario usuarios)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new NpgsqlConnection(connectionString))
            {

                try
                {
                    await con.OpenAsync();
                    var query = "UPDATE infractores SET cedula=@cedula,tipo_ident=@tipo_ident,nombre=@nombre,direccion=@direccion,tel=@tel,licencia=@licencia,ciudad=@ciudad,correo=@correo,apellidos=@apelidos,categoria,ciudad_lic=@ciudad_lic WHERE id = @id";
                    count =((await con.ExecuteAsync(query, usuarios)));
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




        public async Task<List<Usuario>> GetAll()
        {
            var connectionString = this.GetConnection();
            List<Usuario> usuarios = new List<Usuario>();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "SELECT * FROM usuarios";
                    usuarios = (await con.QueryAsync<Usuario>(query)).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

                return usuarios;
            }
        }

        public async Task<Usuario> GetUserById(int id)
        {
            var connectionString = this.GetConnection();
            Usuario usuarios = new Usuario();

            using (var con = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await con.OpenAsync();
                    var query = "SELECT * FROM infractores WHERE id =" + id;
                    usuarios = (await con.QueryAsync<Usuario>(query)).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return usuarios;
            }
        }
    }
}
