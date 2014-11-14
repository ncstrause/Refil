using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefilWeb.Models;

namespace RefilWeb.Repository
{
    public interface IMeetingRepository
    {
        void Create(Meeting meeting);
        IEnumerable<Meeting> GetAll();
        Meeting Get(int id);
        void Update(Meeting meeting);
    }
}
