using System;

namespace RefilWeb.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Summary { get; set; }
        public virtual User Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public int Votes { get; set; }
        public virtual Meeting Meeting { get; set; }
    }
}