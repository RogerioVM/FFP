using FFP.Context;
using FFP.Models;
using Microsoft.EntityFrameworkCore;

namespace FFP.Services
{
    public class TimeService : ITimeService
    {
        private readonly DataContext _dataContext;
        public TimeService(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }


        public async Task<IEnumerable<Time>> GetTimes()
        {
            return await _dataContext.Times.ToListAsync();
        }
        public async Task<Time> GetTimeById(int id)
        {
            var time = await _dataContext.Times.FindAsync(id);
            return time;
        }
        public async Task<IEnumerable<Time>> GetTimesByName(string name)
        {
            IEnumerable<Time> times;
            if(!string.IsNullOrEmpty(name))
            {
                times = await _dataContext.Times
                    .Where( t => t.Nome.Contains(name))
                    .ToListAsync();
            }
            else
            {
                times =  await GetTimes();
            }
            return times;
        }
        public async Task Create(Time time)
        {
            _dataContext.Times.Add(time);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Update(Time time)
        {
            _dataContext.Entry(time).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }
        public async Task Delete(Time id)
        {
            _dataContext.Times.Remove(id);
            await _dataContext.SaveChangesAsync();
        }
    }
}
