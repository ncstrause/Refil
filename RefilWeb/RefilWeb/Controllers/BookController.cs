using System.Web.Mvc;
using RefilWeb.Authentication;
using RefilWeb.Models;
using RefilWeb.Models.ViewModels;

namespace RefilWeb.Controllers
{
    [RoutePrefix("meetings/{meetingId}/books")]
    public class BookController : BaseController
    {
        [RefilAuthorize]
        [Route("list"), HttpGet]
        public ActionResult GetList(int meetingId)
        {
            var books = BookService.GetForMeeting(meetingId);
            return View("BookList", new BookListViewModel{Books = books, Meeting = MeetingService.Get(meetingId)});
        }

        [RefilAuthorize]
        [Route("suggest"), HttpGet]
        public ActionResult GetCreate()
        {
            return View("BookCreate");
        }

        [RefilAuthorize]
        [Route("suggest"), HttpPost]
        public ActionResult PostCreate(SuggestBookViewModel model, int meetingId)
        {
            BookService.Create(new Book
            {
                Creator = UserService.Get(User.UserId),
                Meeting = MeetingService.Get(meetingId),
                Title = model.Title,
                Author = model.Author,
                Genre = model.Genre,
                Summary = model.Summary
            });

            return Redirect("/meetings/" + meetingId + "/books/list");
        }

        [RefilAuthorize]
        [Route("{bookId}/upvote")]
        public ActionResult VoteUp(int bookId, string meetingId)
        {
            BookService.Upvote(bookId, UserService.Get(User.UserId));
            return Redirect("/meetings/" + meetingId + "/books/list");
        }

        [RefilAuthorize]
        [Route("{bookId}/downvote")]
        public ActionResult VoteDown(int bookId, string meetingId)
        {
            BookService.Downvote(bookId, UserService.Get(User.UserId));
            return Redirect("/meetings/" + meetingId + "/books/list");
        }

        [RefilAuthorize(Roles = "Admin")]
        [Route("process"), HttpGet]
        public ActionResult GetProcess(int meetingId)
        {
            return View("BookProcess", MeetingService.Get(meetingId));
        }

        [RefilAuthorize(Roles = "Admin")]
        [Route("process"), HttpPost]
        public ActionResult PostProcess(int meetingId)
        {
            BookService.ProcessBooksForMeeting(meetingId);

            return Redirect("/meetings/list");
        }
    }
}