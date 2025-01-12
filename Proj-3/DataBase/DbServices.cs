using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Proj_3.Models;


namespace Proj_3.DataBase
{
    public class DbServices : DbContext
    {
        DbSet<User> Users { get; set;}
        public DbServices(DbContextOptions<DbServices> options) : base(options)
        {
        }
    }
}
    
