using RefilWeb.Validation;

namespace RefilWeb.Service
{
    public interface IEmailService
    {
        IServiceValidationResponse SendEmail(string to, string from, string subject, string body);
    }
}
