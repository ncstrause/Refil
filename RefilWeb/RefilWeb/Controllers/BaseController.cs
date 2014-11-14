using System.Collections.Specialized;
using System.Web.Configuration;
using System.Web.Mvc;
using RefilWeb.Authentication;
using RefilWeb.Models;
using RefilWeb.Service;

namespace RefilWeb.Controllers
{
    public class BaseController : Controller
    {
        protected virtual new RefilPrincipal User { get { return HttpContext.User as RefilPrincipal; } }
        protected static RefilContext Context = new RefilContext();
        protected static IAnnouncementService AnnouncementService = new AnnouncementService(Context);
        protected static IBookService BookService = new BookService(Context);
        protected static IMeetingService MeetingService = new MeetingService(Context);
        protected static IUserService UserService = new UserService(Context);

        protected static NameValueCollection AppSettings { get { return WebConfigurationManager.AppSettings; } }
    }
}