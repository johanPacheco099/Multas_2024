using Multas.Models;

namespace Multas.Shared.Services.SUser
{
    public interface IUserService
    {
        Task<int> AddUser(Usuario usuarios);

        Task<List<Usuario>> GetAll();

        Task<int> UpdateUser(Usuario usuarios);

        Task<int> DeleteUsuarioById(int id);

        Task<Usuario> GetUserById(int id);
    }
}
