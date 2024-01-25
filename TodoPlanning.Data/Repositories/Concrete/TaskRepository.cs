using TodoPlanning.Data.Entities;
using TodoPlanning.Data.Repositories.Abstract;

namespace TodoPlanning.Data.Repositories.Concrete
{
    public class TaskRepository : GenericRepository<Tasks>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext context) : base(context) { }
    }
}
