using Microsoft.EntityFrameworkCore;
using SignupAndLoginDLL.Models;

namespace Model
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {

        }
        public DbSet<UsersModel> UsersModels { get; set; }
    }
}