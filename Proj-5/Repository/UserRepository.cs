using Proj_5.Database;
using Proj_5.Interfaces;
using Proj_5.Models;

namespace Proj_5.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly DataService _dataService;
        public UserRepository(DataService dataService) 
        {
            _dataService = dataService;
        }
        public ICollection<User> GetUsers()
        {
            return _dataService.Users.OrderBy(x => x.Id).ToList();
        }
    }
}
