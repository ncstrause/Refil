using System.ComponentModel.DataAnnotations;

namespace RefilWeb.Models.ViewModels
{
    public class SuggestBookViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Summary { get; set; }
    }
}