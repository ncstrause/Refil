using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RefilWeb.Authentication;

namespace RefilWeb.Models
{
    public class RefilContext : DbContext
    {
        public RefilContext() : base("DefaultConnection") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Roles).WithMany(r => r.Users).Map(m => 
                {
                    m.ToTable("UserRoles");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
            modelBuilder.Entity<Meeting>().HasOptional(m => m.Book).WithOptionalPrincipal().Map(m =>
                {
                    m.MapKey("MeetingId");
                });
            modelBuilder.Entity<User>().HasMany(u => u.UpvotedBooks).WithOptional().Map(m =>
                {
                    m.MapKey("UpvotedBook_Id");
                });
            modelBuilder.Entity<User>().HasMany(u => u.DownvotedBooks).WithOptional().Map(m =>
                {
                    m.MapKey("DownvotedBook_Id");
                });
        }
    }
}