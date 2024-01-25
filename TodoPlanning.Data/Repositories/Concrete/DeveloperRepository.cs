using TodoPlanning.Data.Entities;
using TodoPlanning.Data.Repositories.Abstract;

namespace TodoPlanning.Data.Repositories.Concrete
{
    public class DeveloperRepository : GenericRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(ApplicationDbContext context) : base(context) { }
    }
}
