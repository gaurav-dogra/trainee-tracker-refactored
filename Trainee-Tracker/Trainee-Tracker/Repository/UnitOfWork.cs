using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Models;

namespace Trainee_Tracker.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public ICourseRepository CourseRepository { get; }
    public ITraineeRepository TraineeRepository { get; }
    public ITrainerRepository TrainerRepository { get; }

    public UnitOfWork(ApplicationDbContext context, ITraineeRepository traineeRepository,
        ICourseRepository courseRepository, ITrainerRepository trainerRepository)
    {
        this._context = context;
        this.CourseRepository = courseRepository;
        this.TraineeRepository = traineeRepository;
        this.TrainerRepository = trainerRepository;
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
