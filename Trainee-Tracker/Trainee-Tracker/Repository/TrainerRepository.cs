using Microsoft.EntityFrameworkCore;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Repository;
public class TrainerRepository : RepositoryBase<Trainer>, ITrainerRepository
{
    public TrainerRepository(ApplicationDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<Trainer>> GetAllTrainersAsync()
    {
        return await GetAll()
            .ToListAsync();
    }

    public async Task<Trainer?> GetTrainerByIdAsync(int trainerId)
    {
        return await GetByCondition(trainer => trainer.Id == trainerId)
            .FirstOrDefaultAsync();
    }

    public async Task<Trainer?> GetTrainerByEmailAsync(string email)
    {
        return await GetByCondition(trainer => trainer.Email == email)
            .FirstOrDefaultAsync();
    }

    public void CreateTrainer(Trainer trainer)
    {
        Add(trainer);
    }

    public void UpdateTrainer(Trainer trainer)
    {
        Update(trainer);
    }

    public void DeleteTrainer(Trainer trainer)
    {
        Remove(trainer);
    }
}
