using System;
using System.Linq;
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
        public ActionResult PostEdit(Meeting meeting)
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

        [RefilAuthorize(Roles = "Admin")]
        [Route("delete"), HttpGet]
        public ActionResult GetDelete(int id)
        {
            try
            {
                var meeting = MeetingService.Get(id);
                return View("MeetingDelete", meeting);
            }
            catch (Exception)
            {
                return Redirect("/meetings/list");
            }
        }

        [RefilAuthorize(Roles = "Admin")]
        [Route("delete"), HttpPost]
        public ActionResult PostDelete(int id)
        {
            try
            {
                var meeting = MeetingService.Get(id);

                var books = BookService.GetAll().Where(b => b.Id == id);

                foreach (var book in books)
                {
                    BookService.Delete(book);
                }

                MeetingService.Delete(meeting);
                return Redirect("/meetings/list");
            }
            catch (Exception e)
            {
                return Redirect("/meetings/list");
            }
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