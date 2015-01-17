namespace RefilWeb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using RefilWeb.Authentication;
    using RefilWeb.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<RefilWeb.Models.RefilContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(RefilContext context)
        {
            //var initialAdmin = new User
            //{
            //    FirstName = "Base",
            //    LastName = "Admin",
            //    Email = "admin@refilclub.org",
            //    Password = "C40F4D3F4104BECACE0E5DD2E1E40E41",
            //    Roles = new List<Role> { RoleDefinitions.User, RoleDefinitions.Admin }
            //};

            //var cynthia = new User
            //{
            //    FirstName = "Cynthia",
            //    LastName = "Jacobs",
            //    Email = "cynthiaajacobs@comcast.net",
            //    Password = "065D879CE820FA34C0AFA8C2E3F88F35",
            //    Roles = new List<Role> { RoleDefinitions.User }
            //};
            //var lisa = new User
            //{
            //    FirstName = "Lisa",
            //    LastName = "Ketchmark",
            //    Email = "lketchmark@mnenduro.com",
            //    Password = "1E02030EBD0BFFFBE4D37ECB64073941",
            //    Roles = new List<Role> { RoleDefinitions.User }
            //};
            //var jean = new User
            //{
            //    FirstName = "Jean",
            //    LastName = "Nelson-Overn",
            //    Email = "nelsoj38@scottsdaleins.com",
            //    Password = "C92ADFA806F564276F632A66C93F21FE",
            //    Roles = new List<Role> { RoleDefinitions.User, RoleDefinitions.Admin }
            //};
            //var sharon = new User
            //{
            //    FirstName = "Sharon",
            //    LastName = "Fiebiger",
            //    Email = "sfiebiger@juno.com",
            //    Password = "C49D83568DF4E4FADE7442DB2199103F",
            //    Roles = new List<Role> { RoleDefinitions.User }
            //};
            //var sharonp = new User
            //{
            //    FirstName = "Sharon",
            //    LastName = "Peter",
            //    Email = "sharontpeter@gmail.com",
            //    Password = "76B26DED7856DBB59A5A3B0047B0F3E7",
            //    Roles = new List<Role> { RoleDefinitions.User }
            //};



            //context.Users.Add(initialAdmin);
            //context.Users.Add(cynthia);
            //context.Users.Add(lisa);
            //context.Users.Add(jean);
            //context.Users.Add(sharon);
            //context.Users.Add(sharonp);
            //context.SaveChanges();
        }
    }
}
