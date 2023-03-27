using FFP.Models;
using System.Collections;

namespace FFP.Services
{
    public interface ITimeService
    {
        Task<IEnumerable<Time>> GetTimes();
        Task<Time> GetTimeById(int id);
        Task<IEnumerable<Time>> GetTimesByName(string name);
        Task Create(Time time);
        Task Update(Time id);
        Task Delete(Time id);
    }
}
