using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefilWeb.Models;

namespace RefilWeb.Repository
{
    public interface IBookRepository
    {
        void Create(Book book);
        void Update(Book book);
        void Delete(Book book);
        IEnumerable<Book> GetAll();
        Book Get(int id);
    }
}
