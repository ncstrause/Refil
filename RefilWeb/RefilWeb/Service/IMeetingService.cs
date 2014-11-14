using System.Collections.Generic;
using RefilWeb.Models;
using RefilWeb.Validation;

namespace RefilWeb.Service
{
    public interface IMeetingService
    {
        void Create(Meeting meeting);
        IEnumerable<Meeting> GetAll();
        Meeting Get(int meetingId);
        IServiceValidationResponse<Meeting> GetNextMeeting();
        void Update(Meeting meeting);
        void SetDrinkProvider(int meetingId, int userId);
        void RemoveDrinkProvider(int meetingId, int userId);
        void SetFoodProvider(int meetingId, int userId);
        void RemoveFoodProvider(int meetingId, int userId);
    }
}
