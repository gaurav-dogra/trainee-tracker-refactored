using Microsoft.EntityFrameworkCore;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Repository;
public class TraineeRepository : RepositoryBase<Trainee>, ITraineeRepository
{
    public TraineeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Trainee>> GetAllTraineesAsync()
    {
        return await GetAll()
            .ToListAsync();
    }

    public async Task<Trainee?> GetTraineeByIdAsync(int traineeId)
    {
        return await GetByCondition(trainee => trainee.Id == traineeId)
            .FirstOrDefaultAsync();
    }

    public void CreateTrainee(Trainee trainee)
    {
       Add(trainee);
    }

    public void UpdateTrainee(Trainee trainee)
    {
        Update(trainee);
    }

    public void RemoveTrainee(Trainee trainee)
    {
       Remove(trainee);
    }
}

