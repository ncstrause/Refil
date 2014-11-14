using System.ComponentModel.DataAnnotations;

namespace RefilWeb.Models.ViewModels
{
    public class SendEmailViewModel
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}