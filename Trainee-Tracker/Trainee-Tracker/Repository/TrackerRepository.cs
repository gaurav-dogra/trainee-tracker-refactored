using Microsoft.EntityFrameworkCore;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Repository;
public class TrackerRepository : RepositoryBase<Tracker>, ITrackerRepository
{
    public TrackerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Tracker>> GetAllTrackersAsync()
    {
        return await GetAll()
            .ToListAsync();
    }

    public async Task<Tracker?> GetTrackersByIdAsync(int trackerId)
    {
        return await GetByCondition(tracker => tracker.Id == trackerId)
            .FirstOrDefaultAsync();
    }

    public void CreateTracker(Tracker tracker)
    {
        Add(tracker);
    }

    public void UpdateTracker(Tracker tracker)
    {
       Update(tracker);
    }

    public void RemoveTracker(Tracker tracker)
    {
        Remove(tracker);
    }
}
