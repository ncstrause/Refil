using System.Collections.Generic;
using System.Linq;
using RefilWeb.Models;
using System.Data.Entity;

namespace RefilWeb.Repository
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly RefilContext context;

        public MeetingRepository(RefilContext context)
        {
            this.context = context;
        }

        public void Create(Meeting meeting)
        {
            context.Meetings.Add(meeting);
            context.SaveChanges(); 
        }

        public IEnumerable<Meeting> GetAll()
        {
            return context.Meetings;
        }

        public Meeting Get(int id)
        {
            return context.Meetings.Single(m => m.Id == id);
        }

        public void Update(Meeting meeting)
        {
            var attachedMeeting = context.Meetings.Attach(meeting);
            context.Entry(attachedMeeting).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Meeting meeting)
        {
            context.Meetings.Remove(meeting);
            context.SaveChanges();
        }
    }
}