using System.Collections.Generic;
using RefilWeb.Models;

namespace RefilWeb.Service
{
    public interface IAnnouncementService
    {
        IEnumerable<Announcement> GetAll();
        IEnumerable<Announcement> GetRecent(int quantity);
        void Create(Announcement announcement, int userId);
        Announcement Get(int id);
        void Update(Announcement announcement);
    }
}
