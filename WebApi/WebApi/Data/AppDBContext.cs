using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<FavoriteArticle> FavoriteArticles => Set<FavoriteArticle>();
    }
}
