using Microsoft.EntityFrameworkCore;
using Multas.Models;

namespace Multas.Shared.Services.SLiquidacion
{
    public class LiquidacionService : ILiquidacionService
    {

        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public LiquidacionService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public async Task<int> Add(Resoluciones resoluciones)
        {
            await _dbContext.resoluciones.AddAsync(resoluciones);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

        public Task<int> GenerarAcuerdoAsync(int h, string pcomp, string pcedula, DateTime pfecha, string pvalor, string pinicial, string pinteres, string pvlr_acuerdo, string pcuotas, string pvlr_recibo)
        {
            throw new NotImplementedException();
        }

        public Task<int> GenerarRecibo(int h, string pcomparendo, string pcedula, string pvalor, string pinteres, string pdescuento, string pacuerdo, string precibo)
        {
            throw new NotImplementedException();
        }

        public Task<List<Procesos>> Getcoactivo(string comparendo)
        {
            throw new NotImplementedException();
        }

        public Task<Liquidaciones> GetComp(string compa)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recibos>> GetRecibos(string comparendop)
        {
           
            var recibos = await _dbContext.recibos
                .Where(r => r.comparendo == comparendop) // Filtra por el comparendo deseado
                .ToListAsync();

            return recibos;
        }


        public Task<List<Resoluciones>> GetResol(string comparendo)
        {
            throw new NotImplementedException();
        }
    }
}
