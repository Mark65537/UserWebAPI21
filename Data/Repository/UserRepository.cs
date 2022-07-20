using UserWebAPI21.Models;

namespace BookWebAPI21.Data.Repository
{
    public class UserRepository
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
    }
}
