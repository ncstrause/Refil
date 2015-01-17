using System;
using System.Collections.Generic;
using System.Linq;
using RefilWeb.Models;
using RefilWeb.Repository;
using RefilWeb.Validation;

namespace RefilWeb.Service
{
    public class MeetingService : IMeetingService
    {
        private readonly MeetingRepository repository;
        private readonly UserService userService;

        public MeetingService(RefilContext context)
        {
            repository = new MeetingRepository(context);
            userService = new UserService(context);
        }

        public void Create(Meeting meeting)
        {
            repository.Create(meeting);
        }

        public IEnumerable<Meeting> GetAll()
        {
            return repository.GetAll();
        }

        public Meeting Get(int meetingId)
        {
            return repository.Get(meetingId);
        }

        public void Delete(Meeting meeting)
        {
            repository.Delete(meeting);
        }

        public IServiceValidationResponse<Meeting> GetNextMeeting()
        {
            var response = new ServiceValidationResponse<Meeting>();
            var meetings = repository.GetAll().ToList();

            if (meetings.Any(m => m.Date > DateTime.Now))
            {
                response.ServiceResultEntity = meetings.Where(m => m.Date > DateTime.Now).OrderBy(m => m.Date).First();
            }
            else
            {
                response.AddError("", "No meetings.");
            }
            

            return response;
        }

        public void Update(Meeting meeting)
        {
            repository.Update(meeting);
        }

        public void SetDrinkProvider(int meetingId, int userId)
        {
            var meeting = Get(meetingId);
            var user = userService.Get(userId).ServiceResultEntity;
            meeting.DrinkProvider = user;
            Update(meeting);
        }

        public void RemoveDrinkProvider(int meetingId, int userId)
        {
            var meeting = Get(meetingId);

            if (userId == meeting.DrinkProvider.UserId)
            {
                meeting.DrinkProvider = null;
                Update(meeting);
            }
        }

        public void SetFoodProvider(int meetingId, int userId)
        {
            var meeting = Get(meetingId);
            var user = userService.Get(userId).ServiceResultEntity;
            meeting.FoodProvider = user;
            Update(meeting);
        }

        public void RemoveFoodProvider(int meetingId, int userId)
        {
            var meeting = Get(meetingId);

            if (userId == meeting.FoodProvider.UserId)
            {
                meeting.FoodProvider = null;
                Update(meeting);
            }
        }
    }
}