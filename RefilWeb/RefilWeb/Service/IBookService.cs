using System.Collections.Generic;
using RefilWeb.Models;

namespace RefilWeb.Service
{
    public interface IBookService
    {
        void Create(Book book);
        void Update(Book book);
        IEnumerable<Book> GetAll();
        Book Get(int id);
        IEnumerable<Book> GetForMeeting(int meetingId);
        void Delete(Book book);
        void Upvote(int bookId, User user);
        void Downvote(int bookId, User user);
        void ProcessBooksForMeeting(int meetingId);
    }
}