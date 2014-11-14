using RefilWeb.Models;

namespace RefilWeb.Authentication
{
    public static class RoleDefinitions
    {
        public static Role Admin
        {
            get
            {
                return new Role
                {
                    Name = "Admin",
                    Description = "Refil Website Administrator"
                };
            }
        }

        public static Role User
        {
            get
            {
                return new Role
                {
                    Name = "User",
                    Description = "Refil Website Standard User"
                };
            }
        }
    }
}