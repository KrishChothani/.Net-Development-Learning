using Proj_5.Models;

namespace Proj_5.Interfaces
{
    public interface IUserInterface
    {
        ICollection<User> GetAllUser();
        User GetUserById(int id);
        bool UserExist(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
