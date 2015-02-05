using System;
using System.Collections.Generic;
using System.Linq;
using RefilWeb.Models;
using System.Data.Entity;

namespace RefilWeb.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RefilContext context;

        public UserRepository(RefilContext context)
        {
            this.context = context;
        }

        public void Create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        
        public User Get(int id)
        {
            return context.Users.SingleOrDefault(u => u.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users;
        }

        public User Get(string email)
        {
            return context.Users.ToList().Single(u => 
                String.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));
        }

        public void Update(User user)
        {
            context.Users.Attach(user);
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }
}