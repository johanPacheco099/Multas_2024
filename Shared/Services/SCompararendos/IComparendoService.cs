using Multas.Models;

namespace Multas.Shared.Services
{
    public interface IComparendoService
    {
              
        Task<Comparendos> Add(Comparendos comparendo);
        Task<List<Comparendos>> GetComparendosByCedula(string cedula);
        Task<List<Comparendos>> GetAll();
        //cambiar a int, dato devuelto
        Task<Comparendos> UpdateMulta(int id, Comparendos updtdedComparendo);

        int DeleteComparendos(int id);

        Task<Comparendos> GetMultasById(int id);

        Task<double> calculoUvts(DateTime pfecha, string pinfraccion, int pgrado, int preincide);
        
    }   
}