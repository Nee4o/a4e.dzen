namespace Ache.Dzen.Bars.Models
{
    public class FavoriteArticle
    {
        public int Id { get; set; }
        public User user { get; set; }
        public Article article { get; set; }
    }
}
