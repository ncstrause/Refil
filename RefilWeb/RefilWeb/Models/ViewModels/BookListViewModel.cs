using System.Collections.Generic;

namespace RefilWeb.Models.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public Meeting Meeting { get; set; }
    }
}