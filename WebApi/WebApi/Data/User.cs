using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class User
    {
        public User()
        {
            this.Article = new HashSet<Article>();
            this.FavoriteArticle = new HashSet<FavoriteArticle>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Article> Article { get; set; }
        public virtual ICollection<FavoriteArticle> FavoriteArticle { get; set; }
    }
}
