using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using System.Web.Configuration;

namespace RefilWeb.Authentication
{
    public class RefilAuthorize : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        protected virtual RefilPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as RefilPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var authorizedUsers = WebConfigurationManager.AppSettings[UsersConfigKey];
                var authrorizedRoles = WebConfigurationManager.AppSettings[RolesConfigKey];

                Users = String.IsNullOrWhiteSpace(Users) ? authorizedUsers : Users;
                Roles = String.IsNullOrWhiteSpace(Roles) ? authrorizedRoles : Roles;

                if (!String.IsNullOrWhiteSpace(Roles) && !CurrentUser.IsInRole(Roles) &&
                    !Users.Contains(CurrentUser.UserId.ToString(CultureInfo.InvariantCulture)))
                {
                    filterContext.Result = new RedirectResult("/authentication/accessdenied");
                }
            }
            else
            {
                base.OnAuthorization(filterContext);
            }
        }
    }
}