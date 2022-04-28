using Trainee_Tracker.Domain.Models;

namespace Trainee_Tracker.Domain.Interfaces;
public interface ITrainerRepository : IRepositoryBase<Trainer>
{
    Task<IEnumerable<Trainer>> GetAllTrainersAsync();
    Task<Trainer?> GetTrainerByIdAsync(int trainerId);
    Task<Trainer?> GetTrainerByEmailAsync(string email);
    void CreateTrainer(Trainer trainer);
    void UpdateTrainer(Trainer trainer);
    void DeleteTrainer(Trainer trainer);
}
