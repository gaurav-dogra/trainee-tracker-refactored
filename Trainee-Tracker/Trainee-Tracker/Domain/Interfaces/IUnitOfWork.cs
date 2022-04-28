namespace Trainee_Tracker.Domain.Interfaces;
public interface IUnitOfWork 
{
    ICourseRepository CourseRepository { get; }
    ITraineeRepository TraineeRepository { get; }
    ITrainerRepository TrainerRepository { get; }
    Task SaveAsync();
}
