using Trainee_Tracker.Domain.Models;

namespace Trainee_Tracker.Domain.Interfaces;
public interface ITraineeRepository : IRepositoryBase<Trainee>
{
    Task<IEnumerable<Trainee>> GetAllTraineesAsync();
    Task<Trainee?> GetTraineeByIdAsync(int traineeId);
    void CreateTrainee(Trainee trainee);
    void UpdateTrainee(Trainee trainee);
    void RemoveTrainee(Trainee trainee);
}