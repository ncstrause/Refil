using System.Web.Mvc;
using RefilWeb.Authentication;
using RefilWeb.Models;
using RefilWeb.Models.ViewModels;

namespace RefilWeb.Controllers
{
    [RefilAuthorize(Roles = "Admin")]
    [RoutePrefix("announcements")]
    public class AnnouncementController : BaseController
    {
        [Route("list"), HttpGet]
        public ActionResult GetList()
        {
            return View("AnnouncementList", AnnouncementService.GetAll());
        }

        [Route("create"), HttpGet]
        public ActionResult GetCreate()
        {
            return View("AnnouncementCreate");
        }
        [Route("create"), HttpPost]
        public ActionResult PostCreate(AnnouncementViewModel announcement)
        {
            if (!ModelState.IsValid) return View("AnnouncementCreate", announcement);

            AnnouncementService.Create(new Announcement
            {
                Message = announcement.Message, 
                Title = announcement.Title
            },User.UserId);

            return Redirect("/announcements/list");
        }

        [Route("{id}/edit"), HttpGet]
        public ActionResult GetEdit(int id)
        {
            AnnouncementService.Get(id);

            return View("AnnouncementEdit");
        }
        [Route("{id}/edit"), HttpPost]
        public ActionResult PostEdit(Announcement announcement)
        {
            AnnouncementService.Update(announcement);

            return Redirect("/announcements/list");
        }

        [Route("{id}/delete"), HttpGet]
        public ActionResult Delete(int id)
        {
            return Redirect("/announcements/list");
        }
    }
}