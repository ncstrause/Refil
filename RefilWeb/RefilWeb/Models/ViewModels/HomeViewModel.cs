using System.Collections.Generic;

namespace RefilWeb.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Announcement> Announcements { get; set; }
        public Meeting NextMeeting { get; set; }
    }
}