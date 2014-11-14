using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using RefilWeb.Models;
using Newtonsoft.Json;
using RefilWeb.Authentication;
using Autofac;
using Autofac.Integration.Mvc;
using RefilWeb.Repository;
using RefilWeb.Service;

namespace RefilWeb
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ConfigureAutoFac();
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null || String.IsNullOrWhiteSpace(authCookie.Value)) return;

            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            var serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
            var user = new RefilPrincipal(authTicket.Name)
            {
                UserId = serializeModel.UserId,
                FirstName = serializeModel.FirstName,
                LastName = serializeModel.LastName,
                Roles = serializeModel.Roles
            };

            HttpContext.Current.User = user;
        }
    
        private void ConfigureAutoFac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<RefilContext>().AsSelf();

            builder.RegisterType<AnnouncementRepository>().As<IAnnouncementRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<MeetingRepository>().As<IMeetingRepository>();

            builder.RegisterType<AnnouncementService>().As<IAnnouncementService>();
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<MeetingService>().As<IMeetingService>();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
