using Microsoft.EntityFrameworkCore;
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

        public bool CreateUser(User user)
        {
            _dataService.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _dataService.Remove(user);
            return Save();
        }

        public ICollection<User> GetAllUser()
        {
            return _dataService.Users.OrderBy(x => x.Id).ToList();
        }

        public User GetUserById(int id)
        {
            return _dataService.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _dataService.SaveChanges();
            Console.WriteLine(saved);
            return saved <= 0 ? false : true;
        }

        public bool UpdateUser(User user)
        {
            _dataService.Update(user);
            return Save();
        }

        public bool UserExist(int id)
        {
            return _dataService.Users.Any(p => p.Id == id);
        }

        
    }
}
