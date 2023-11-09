using GenericRepository.Application.Repositories;
using LoginForm.Contracts;
using LoginForm.Data;
using LoginForm.Models;

namespace LoginForm.Repositories { 

    public class PlaydateRepository : GenericRepository<PlayDate>, IPlaydateRepository
    {
        public PlaydateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}