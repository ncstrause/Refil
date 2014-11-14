using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RefilWeb.Authentication;
using RefilWeb.Models.ViewModels;
using RefilWeb.Service;

namespace RefilWeb.Controllers
{
    [RefilAuthorize(Roles = "Admin")]
    [RoutePrefix("admin")]
    public class AdminController : BaseController
    {
        private readonly IEmailService emailService = new EmailService(
            new NetworkCredential(AppSettings["smtpUser"], AppSettings["smtpPassword"]), 
            AppSettings["smtpAddress"], 
            Int32.Parse(AppSettings["smtpPort"]));
        
        [Route("home"), HttpGet]
        public ActionResult GetAdminView()
        {
            return View("AdminHome");
        }

        [Route("email"), HttpGet]
        public ActionResult GetSendEmail()
        {
            return View("AdminEmail");
        }

        [Route("email"), HttpPost]
        public ActionResult PostSendEmail(SendEmailViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("AdminEmail", viewModel);

            var response = emailService.SendEmail(GetAllUserEmailAddresses(), 
                UserService.Get(User.UserId).Email, viewModel.Subject, viewModel.Body);

            if (response.IsValid)
            {
                ViewBag.SuccessMessages = new List<String> { "Email sent to all users." };
            }
            else
            {
                ViewBag.ErrorMessages = response.GetErrors().Select(e => e.Value);
            }

            return View("AdminHome");
        }

        [Route("promote"), HttpGet]
        public ActionResult GetAdminPromote()
        {
            return View("AdminPromote", UserService.GetAll().Where(u => u.Roles.All(r => r.Name != "Admin")));
        }

        [Route("promote/{userId}"), HttpGet]
        public ActionResult GetAdminPromote(int userId)
        {
            var response = UserService.PromoteToAdmin(userId);

            if (!response.IsValid)
            {
                ViewBag.ErrorMessages = response.GetErrors().Select(e => e.Value);
            }

            return Redirect("/admin/home");
        }

        private string GetAllUserEmailAddresses()
        {
            var emails = UserService.GetAll().Select(u => u.Email);
            return String.Join(",", emails);
        }
    }
}