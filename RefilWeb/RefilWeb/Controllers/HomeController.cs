using System.Linq;
using System.Web.Mvc;
using RefilWeb.Authentication;
using RefilWeb.Models.ViewModels;

namespace RefilWeb.Controllers
{
    [RefilAuthorize]
    public class HomeController : BaseController
    {
        [Route("home"), HttpGet]
        public ActionResult GetHome()
        {
            var model = new HomeViewModel
            {
                Announcements = AnnouncementService.GetRecent(3),
                NextMeeting = null
            };

            var response = MeetingService.GetNextMeeting();
            if (response.IsValid)
            {
                model.NextMeeting = response.ServiceResultEntity;
            }
            return View("Home", model);
        }

        [Route("books/chooseMeeting")]
        public ActionResult GetChooseMeeting()
        {
            var meetings = MeetingService.GetAll().OrderBy(m => m.Date).Take(50);
            return View("BookChooseMeeting", meetings);
        }
    }
}