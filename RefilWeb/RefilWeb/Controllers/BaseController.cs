using System.Collections.Specialized;
using System.Data.Entity;
using System.Web.Configuration;
using System.Web.Mvc;
using RefilWeb.Authentication;
using RefilWeb.Models;
using RefilWeb.Service;

namespace RefilWeb.Controllers
{
    public class BaseController : Controller
    {
        protected static NameValueCollection AppSettings { get { return WebConfigurationManager.AppSettings; } }
        protected virtual new RefilPrincipal User { get { return HttpContext.User as RefilPrincipal; } }

        protected readonly IAnnouncementService AnnouncementService;
        protected readonly IBookService BookService;
        protected readonly IMeetingService MeetingService;
        protected readonly IUserService UserService;

        private readonly RefilContext context;

        public BaseController()
        {
            context = new RefilContext();
            AnnouncementService = new AnnouncementService(context);
            BookService = new BookService(context);
            MeetingService = new MeetingService(context);
            UserService = new UserService(context);
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();

            base.Dispose(disposing);
        }
    }
}