using System.Collections.Generic;
using RefilWeb.Models;
using RefilWeb.Validation;

namespace RefilWeb.Service
{
    public interface IUserService
    {
        IServiceValidationResponse Create(User user);
        User Get(int id);
        void Update(User user);
        IServiceValidationResponse<User> AuthenticateUser(string email, string password);
        IEnumerable<User> GetAll();
        IServiceValidationResponse PromoteToAdmin(int id);
    }
}
