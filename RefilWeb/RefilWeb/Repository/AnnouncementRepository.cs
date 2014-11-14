using System.Collections.Generic;
using System.Linq;
using RefilWeb.Models;
using System.Data.Entity;

namespace RefilWeb.Repository
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly RefilContext context;

        public AnnouncementRepository(RefilContext context)
        {
            this.context = context;
        }

        public IEnumerable<Announcement> GetAll()
        {
            return context.Announcements;
        }

        public void Create(Announcement announcement)
        {
            context.Announcements.Add(announcement);
            context.SaveChanges();
        }

        public void Delete(Announcement announcement)
        {
            context.Announcements.Remove(announcement);
            context.SaveChanges();
        }

        public void Update(Announcement announcement)
        {
            var attachedAnnouncement = context.Announcements.Attach(announcement);
            context.Entry(attachedAnnouncement).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Announcement Get(int id)
        {
            return context.Announcements.Single(m => m.Id == id);
        }
    }
}