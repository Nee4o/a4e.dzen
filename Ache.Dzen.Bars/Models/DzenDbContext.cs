using Microsoft.EntityFrameworkCore;

namespace Ache.Dzen.Bars.Models
{
    public class DzenDbContext:DbContext
    {
        public DbSet<User> _userContext { get; set; }
        public DbSet<Article> _articleContext { get; set; }
        public DbSet<FavoriteArticle> _favartContext { get; set; }
        public DzenDbContext(DbContextOptions<DzenDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
