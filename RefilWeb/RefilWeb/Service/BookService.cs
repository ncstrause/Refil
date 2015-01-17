using System;
using System.Collections.Generic;
using System.Linq;
using RefilWeb.Models;
using RefilWeb.Repository;

namespace RefilWeb.Service
{
    public class BookService : IBookService
    {
        private readonly BookRepository repository;
        private readonly UserService userService;
        private readonly MeetingService meetingService;

        public BookService(RefilContext context)
        {
            repository = new BookRepository(context);
            userService = new UserService(context);
            meetingService = new MeetingService(context);
        }

        public void Create(Book book)
        {
            book.CreateDate = DateTime.Now;
            book.Votes = 0;

            repository.Create(book);
        }

        public void Update(Book book)
        {
            repository.Update(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public Book Get(int id)
        {
            return repository.Get(id);
        }

        public IEnumerable<Book> GetForMeeting(int meetingId)
        {
            var meeting = meetingService.Get(meetingId);
            return repository.GetAll().Where(m => m.Meeting == meeting).ToList();
        }

        public void Delete(Book book)
        {
            repository.Delete(book);
        }

        public void Upvote(int bookId, User user)
        {
            var book = Get(bookId);

            if (user.DownvotedBooks.Contains(book))
            {
                user.DownvotedBooks.Remove(book);
                book.Votes += 1;
            }

            if (!user.UpvotedBooks.Contains(book))
            {
                book.Votes += 1;
                Update(book);

                user.UpvotedBooks.Add(book);
                userService.Update(user);
            }
        }

        public void Downvote(int bookId, User user)
        {
            var book = Get(bookId);

            if (user.UpvotedBooks.Contains(book))
            {
                user.UpvotedBooks.Remove(book);
                book.Votes -= 1;
            }

            if (!user.DownvotedBooks.Contains(book))
            {
                book.Votes -= 1;
                Update(book);

                user.DownvotedBooks.Add(book);
                userService.Update(user);
            }
        }

        public void ProcessBooksForMeeting(int meetingId)
        {
            var meeting = meetingService.Get(meetingId);
            meeting.Book = GetForMeeting(meetingId).OrderByDescending(b => b.Votes).First();
            meetingService.Update(meeting);
        }
    }
}