using Multas.Models;

namespace Multas.Shared.Services.SCoactivo
{
    public interface ICoactivoService
    {
        Task<List<Coactivos>> GetList();

        Task<List<Coactivos>> GetList1(string x);
        Task<int> Pasar_coactivo(string id);
    }
}
