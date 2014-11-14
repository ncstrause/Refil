using System;
using System.Net;
using System.Net.Mail;
using RefilWeb.Validation;

namespace RefilWeb.Service
{
    public class EmailService : IEmailService
    {
        private readonly NetworkCredential credential;
        private readonly string address;
        private readonly int port;

        public EmailService(NetworkCredential credential, string address, int port)
        {
            this.credential = credential;
            this.address = address;
            this.port = port;
        }

        public IServiceValidationResponse SendEmail(string to, string from, string subject, string body)
        {
            var response = new ServiceValidationResponse();

            using (var client = new SmtpClient(address, port)
            {
                Credentials = credential,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            })
            {
                client.ServicePoint.MaxIdleTime = 1;
                var email = new MailMessage(from, to, subject, body);

                try
                {
                    client.Send(email);
                }
                catch (Exception)
                {
                    response.AddError("", "Failed to send email. This definitely should not happen!");
                }
                
                
            }

            return response;
        }
    }
}