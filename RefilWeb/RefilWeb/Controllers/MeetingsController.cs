using System.Web.Mvc;
using RefilWeb.Authentication;
using RefilWeb.Models;

namespace RefilWeb.Controllers
{
    [RoutePrefix("meetings")]
    public class MeetingsController : BaseController
    {
        [RefilAuthorize(Roles = "Admin")]
        [Route("create"), HttpGet]
        public ActionResult GetCreate()
        {
            return View("CreateMeeting");
        }

        [RefilAuthorize(Roles = "Admin")]
        [Route("create"), HttpPost]
        public ActionResult PostCreate(Meeting meeting)
        {
            MeetingService.Create(meeting);

            return Redirect("/meetings/list");
        }

        [RefilAuthorize(Roles = "Admin")]
        [Route("{meetingId}/edit"), HttpGet]
        public ActionResult GetEdit(int meetingId)
        {
            var meeting = MeetingService.Get(meetingId);

            return View("MeetingEdit", meeting);
        }

        [RefilAuthorize(Roles = "Admin")]
        [Route("{meetingId}/edit"), HttpPost]
        public ActionResult GetEdit(Meeting meeting)
        {
            MeetingService.Update(meeting);

            return Redirect("/meetings/list");
        }

        [RefilAuthorize]
        [Route("list"), HttpGet]
        public ActionResult GetList()
        {
            return View("MeetingList", MeetingService.GetAll());
        }

        [RefilAuthorize]
        [Route("{meetingId}/drink/register"), HttpGet]
        public ActionResult EditDrinkProvider(int meetingId)
        {
            MeetingService.SetDrinkProvider(meetingId, User.UserId);

            return Redirect("/meetings/list");
        }

        [RefilAuthorize]
        [Route("{meetingId}/drink/unregister"), HttpGet]
        public ActionResult UnregisterDrinkProvider(int meetingId)
        {
            MeetingService.RemoveDrinkProvider(meetingId, User.UserId);

            return Redirect("/meetings/list");
        }

        [RefilAuthorize]
        [Route("{meetingId}/food/register"), HttpGet]
        public ActionResult EditFoodProvider(int meetingId)
        {
            MeetingService.SetFoodProvider(meetingId, User.UserId);

            return Redirect("/meetings/list");
        }

        [RefilAuthorize]
        [Route("{meetingId}/food/unregister"), HttpGet]
        public ActionResult UnregisterFoodProvider(int meetingId)
        {
            MeetingService.RemoveFoodProvider(meetingId, User.UserId);

            return Redirect("/meetings/list");
        }
    }
}