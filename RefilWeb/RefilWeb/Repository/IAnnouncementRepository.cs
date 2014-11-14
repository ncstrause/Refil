using System.Collections.Generic;
using RefilWeb.Models;

namespace RefilWeb.Repository
{
    public interface IAnnouncementRepository
    {
        IEnumerable<Announcement> GetAll();
        void Create(Announcement announcement);
        void Delete(Announcement announcement);
        void Update(Announcement announcement);
        Announcement Get(int id);
    }
}
