using Proj_3.DataBase;

namespace Proj_3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public static implicit operator User(DbServices v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
