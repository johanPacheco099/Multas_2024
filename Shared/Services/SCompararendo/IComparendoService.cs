using Multas.Models;

namespace Multas.Shared.Services
{
    public interface IComparendoService
    {
              
        Task<Comparendos> Add(Comparendos comparendo);

        Task<List<Comparendos>> GetAll();

        Task<Comparendos> UpdateMulta(int id);

        int DeleteComparendos(int id);

        Task<Comparendos> GetMultasById(int id);
        
    }   
}