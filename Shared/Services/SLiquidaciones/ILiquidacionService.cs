using Multas.Models;

namespace Multas.Shared.Services.SLiquidacion
{
    public interface ILiquidacionService
    {
        Task<List<Recibos>> GetRecibos();
        Task<int> GenerarAcuerdo(int h, string pcomp, string pcedula, DateTime pfecha, string pvalor, string pinicial, string pinteres, string pvlr_acuerdo, string pcuotas, string pvlr_recibo);
        Task<int> GenerarRecibo(int h, string pcomparendo, string pcedula, string pvalor, string pinteres, string pdescuento, string pacuerdo, string precibo);
        Task<int> Add(Resoluciones resoluciones);
        Task<List<Resoluciones>> GetResol(string comparendo);
        Task<List<Procesos>> Getcoactivo(string comparendo);
        Task<Liquidaciones> GetComp(string compa);
    }
}
