using System;
using System.Collections.Generic;
using System.Linq;
using RefilWeb.Models;
using RefilWeb.Repository;

namespace RefilWeb.Service
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly AnnouncementRepository repository;
        private readonly UserService userService;

        public AnnouncementService(RefilContext context)
        {
            this.repository = new AnnouncementRepository(context);
            this.userService = new UserService(context);
        }

        public IEnumerable<Announcement> GetAll()
        {
            return repository.GetAll();
        }

        public IEnumerable<Announcement> GetRecent(int quantity)
        {
            return repository.GetAll().OrderBy(a => a.CreateDate).Take(quantity);
        }

        public void Create(Announcement announcement, int userId)
        {
            var user = userService.Get(userId);
            announcement.Creator = user;
            announcement.CreateDate = DateTime.Now;
            repository.Create(announcement);
        }

        public Announcement Get(int id)
        {
            return repository.Get(id);
        }

        public void Update(Announcement announcement)
        {
            repository.Update(announcement);
        }
    }
}