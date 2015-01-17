using System.Collections.Generic;
using RefilWeb.Models;

namespace RefilWeb.Repository
{
    public interface IMeetingRepository
    {
        void Create(Meeting meeting);
        IEnumerable<Meeting> GetAll();
        Meeting Get(int id);
        void Update(Meeting meeting);
        void Delete(Meeting meeting);
    }
}
