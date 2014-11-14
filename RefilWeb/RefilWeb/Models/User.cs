using System.Collections.Generic;

namespace RefilWeb.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get
        {
            return FirstName != null && LastName != null ? FirstName + " " + LastName : null;
        } }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Book> UpvotedBooks { get; set; }
        public virtual ICollection<Book> DownvotedBooks { get; set; }
    }
}