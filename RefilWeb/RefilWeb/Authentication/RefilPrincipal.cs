using System.Linq;
using System.Security.Principal;

namespace RefilWeb.Authentication
{
    public class RefilPrincipal : IPrincipal
    {
        public int UserId { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }

        public bool IsAdmin { get { return IsInRole("Admin"); } }

        public RefilPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return Roles.Any(r => r == role);
        }
    }
}