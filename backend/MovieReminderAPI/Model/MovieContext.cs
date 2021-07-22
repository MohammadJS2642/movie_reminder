using Microsoft.EntityFrameworkCore;
using SignupAndLoginDLL.Models;
using MovieTableDLL.Models;

namespace MovieReminderAPI.Model
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {

        }
        public DbSet<UsersModel> UsersModels { get; set; }
        public DbSet<MovieModels> MovieModels { get; set; }
    }
}