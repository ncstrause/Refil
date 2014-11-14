using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RefilWeb.Models;
using System.Web.Security;
using RefilWeb.Models.ViewModels;
using Newtonsoft.Json;

namespace RefilWeb.Controllers
{
    [RoutePrefix("authentication")]
    public class AuthenticationController : BaseController
    {
        [Route("login"), HttpGet]
        public ActionResult GetLogin()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/home");
            }

            return View("LoginView");
        }

        [Route("login"), HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (!ModelState.IsValid) return View("LoginView", model);
            
            var serviceResponse = UserService.AuthenticateUser(model.Email, model.Password);

            if (serviceResponse.IsValid)
            {
                var user = serviceResponse.ServiceResultEntity;

                var serializeModel = new CustomPrincipalSerializeModel
                {
                    UserId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = user.Roles.Select(r => r.Name).ToArray()
                };

                var userData = JsonConvert.SerializeObject(serializeModel);

                var ticket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(120), false, userData);
                var encTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(cookie);

                if (!String.IsNullOrWhiteSpace(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return Redirect("/home");
            }

            foreach (var error in serviceResponse.GetErrors())
            {
                ModelState.AddModelError(error.Key, error.Value);
            }

            return View("LoginView", model);
        }

        [Route("logout"), HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/home");
        }

        [Route("accessdenied"), HttpGet]
        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}