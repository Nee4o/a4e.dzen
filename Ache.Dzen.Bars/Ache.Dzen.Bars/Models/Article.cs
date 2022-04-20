using Ache.Dzen.Bars.Models;
using System;

namespace Ache.Dzen.Bars
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[]? Binary { get; set; }
        public string? Date { get; set; }
        public int UserId { get; set; }
        public User? user { get; set; }

    }
}
