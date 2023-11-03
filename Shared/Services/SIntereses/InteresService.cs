using Multas.Models;

namespace Multas.Shared.Services.SInteres
{
    public class InteresService : IInteresService
    {
        private readonly IConfiguration _configuration; // para usar dapper
        private readonly AppDbContext _dbContext; // para usar Entity Framework

        public InteresService(IConfiguration configuration, AppDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }
        public Task<int> AddInteres(Intereses intereses)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteIntereses(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditIntereses(Intereses intereses)
        {
            throw new NotImplementedException();
        }

        public Task<Intereses> GetInteresesById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Intereses>> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
