using Microsoft.EntityFrameworkCore;
using SignupAndLoginDLL.Model;

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