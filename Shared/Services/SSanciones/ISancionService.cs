using Multas.Models;

namespace Multas.Shared.Services.SSanciones
{
    public interface ISancionService
    {
        Task<List<Sanciones>> GetAll();

        //List<Sanciones> GetList1(string x);
        Task<int> Sancionar(string id);
    }
}
