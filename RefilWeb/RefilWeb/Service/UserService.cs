using System.Linq;
using System.Security.Cryptography;
using System.Text;
using RefilWeb.Authentication;
using RefilWeb.Models;
using RefilWeb.Repository;
using System.Collections.Generic;
using RefilWeb.Validation;

namespace RefilWeb.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository repository;

        public UserService(RefilContext context)
        {
            repository = new UserRepository(context);
        }

        public IServiceValidationResponse Create(User user)
        {
            var response = new ServiceValidationResponse();

            if (repository.GetAll().All(u => u.Email != user.Email))
            {
                user.Roles = new List<Role> { RoleDefinitions.User };
                user.Password = Md5Hash(user.Password);
                repository.Create(user);
            }
            else
            {
                response.AddError("", "That email is already registered.");
            }

            return response;
        }

        public IServiceValidationResponse<User> Get(int id)
        {
            var response = new ServiceValidationResponse<User>();

            var user = repository.Get(id);
            if (user != null)
            {
                response.ServiceResultEntity = user;
            }
            else
            {
                response.AddError("Id", "User does not exist");
            }

            return response;
        }

        public IServiceValidationResponse Delete(User user)
        {
            var response = new ServiceValidationResponse();
            if (repository.GetAll().Any(u => u.UserId == user.UserId))
            {
                repository.Delete(user);
            }
            else
            {
                response.AddError("Id", "That user does not exist");
            }

            return response;
        }

        public void Update(User user)
        {
            repository.Update(user);
        }

        public IServiceValidationResponse<User> AuthenticateUser(string email, string password)
        {
            var response = new ServiceValidationResponse<User>();
            var hashedPassword = Md5Hash(password);

            if (repository.GetAll().Any(u => u.Email == email))
            {
                var user = repository.Get(email);

                if (hashedPassword == user.Password)
                {
                    response.ServiceResultEntity = user;
                }
                else
                {
                    response.AddError("Password", "Invalid email password combination");
                }
            }
            else
            {
                response.AddError("Email", "That email is not registered.");
            }

            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        public IServiceValidationResponse PromoteToAdmin(int id)
        {
            var response = new ServiceValidationResponse();

            if (repository.GetAll().Any(u => u.UserId == id))
            {
                var user = Get(id).ServiceResultEntity;

                if (user.Roles.All(r => r.Name != "Admin"))
                {
                    user.Roles.Add(RoleDefinitions.Admin);
                }
                else
                {
                    response.AddError("", "User is already an admin");
                }
            }
            else
            {
                response.AddError("", "User not found.");
            }
            
            return response;
        }

        public static string Md5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}