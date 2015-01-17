using System.Collections.Generic;
using RefilWeb.Models;

namespace RefilWeb.Repository
{
    public interface IUserRepository
    {
        void Create(User user);
        User Get(int id);
        IEnumerable<User> GetAll();
        void Update(User user);
        void Delete(User user);
    }
}
