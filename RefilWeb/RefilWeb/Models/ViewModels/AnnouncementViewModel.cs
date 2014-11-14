using System.ComponentModel.DataAnnotations;

namespace RefilWeb.Models.ViewModels
{
    public class AnnouncementViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }
    }
}