using Trainee_Tracker.Domain.Models;

namespace Trainee_Tracker.Domain.Interfaces;
public interface ITrackerRepository : IRepositoryBase<Tracker>
{
    Task<IEnumerable<Tracker>> GetAllTrackersAsync();

    // is the ? avoidable here
    Task<Tracker?> GetTrackersByIdAsync(int trainerId);
    void CreateTracker(Tracker tracker);
    void UpdateTracker(Tracker tracker);
    void RemoveTracker(Tracker tracker);
}
