using Multas.Models;

namespace Multas.Shared.Services.SInfracciones
{


    public interface IInfraccionesService
    {
        Task<string> GetNameInfraccionByCode(string code);
    }
}
