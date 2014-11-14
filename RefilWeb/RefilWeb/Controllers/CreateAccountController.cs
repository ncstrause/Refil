using System.Web.Mvc;
using RefilWeb.Models;
using RefilWeb.Models.ViewModels;

namespace RefilWeb.Controllers
{
    public class CreateAccountController : BaseController
    {
        [Route("create-account"), HttpGet]
        public ActionResult GetCreateAccount()
        {
            return View("CreateAccount");
        }

        [Route("create-account"), HttpPost]
        public ActionResult PostCreateAccount(CreateAccountViewModel model)
        {
            if (!ModelState.IsValid) return View("CreateAccount", model);
            
            var response = UserService.Create(new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                });

            if (response.IsValid)
            {
                return Redirect("/home");
            }

            foreach (var error in response.GetErrors())
            {
                ModelState.AddModelError(error.Key, error.Value);
            }

            return View("CreateAccount", model);
            
        }
    }
}