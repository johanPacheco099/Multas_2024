using Multas.Models;

namespace Multas.Shared.Services.SInteres
{
    public interface IInteresService
    {
        Task<int> AddInteres(Intereses intereses);

        Task<List<Intereses>> GetList(); //GetAll()?

        Task<int> EditIntereses(Intereses intereses);

        Task<int> DeleteIntereses(int id);

       Task<Intereses> GetInteresesById(int id);
    }
}
