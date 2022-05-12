using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class FavoriteArticle
    {
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }

    }
}
