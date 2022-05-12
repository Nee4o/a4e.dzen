using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class Article
    {
        public Article()
        {
            this.FavoriteArticle = new HashSet<FavoriteArticle>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[]? Image { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<int> UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<FavoriteArticle> FavoriteArticle { get; set; }
    }
}
