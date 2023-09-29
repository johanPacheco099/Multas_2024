using Multas.Models;

namespace Multas.Shared.Services.SParametros
{
    public interface IParametroService
    {
        Task<List<Parametros>> GetAll();

        Task<int> EditParametros(int id, Parametros updateParametro);

        Task<int>GetParametroById(int id);
    }
}
