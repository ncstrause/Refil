using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RefilWeb.Models;
using System.Data.Entity;

namespace RefilWeb.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly RefilContext context;

        public BookRepository(RefilContext context)
        {
            this.context = context;
        }

        public void Create(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void Update(Book book)
        {
            var attachedBook = context.Books.Attach(book);
            context.Entry(attachedBook).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }

        public Book Get(int id)
        {
            return context.Books.Single(b => b.Id == id);
        }
    }
}