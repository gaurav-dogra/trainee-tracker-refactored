using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Trainee_Tracker.Domain.Interfaces;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;
using Trainee_Tracker.Repository;

namespace TrackerTests.RepositoryTests;

public class TraineeRepositoryTests
{
    private UnitOfWork _uow = null!;
    private ApplicationDbContext _context = null!;

    [SetUp]
    public void OneTimeSetUp()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemory").Options;
        _context = new ApplicationDbContext(options);
        
        _context.Database.EnsureCreated();

        ITraineeRepository traineeRepository = new TraineeRepository(_context);
        ICourseRepository courseRepository = new CourseRepository(_context);
        ITrainerRepository trainerRepository = new TrainerRepository(_context);

        _uow = new UnitOfWork(_context, traineeRepository, courseRepository, trainerRepository);

        SeedDatabase();
    }

    [TearDown]
    public void OneTimeTearDown()
    {
        _context.Database.EnsureDeleted();
    }

    private void SeedDatabase()
    {
        TestsSeedData.CourseList
            .ForEach(_uow.CourseRepository.CreateCourse);

        TestsSeedData.TraineeList
            .ForEach(_uow.TraineeRepository.CreateTrainee);

        _uow.SaveAsync().Wait();
    }

    [Test]
    public void TraineesRepository_SuccessfulConstruction()
    {
        Assert.That(_uow.TraineeRepository, Is.InstanceOf<TraineeRepository>());
    }

    [Test]
    public void GetAllTraineesAsync_IsWorking()
    {
        var result = _uow.TraineeRepository.GetAllTraineesAsync()
            .Result
            .Count();
        const int traineeSeedDataSize = 3;
        Assert.That(result, Is.EqualTo(traineeSeedDataSize));
    }

    [Test]
    public void CreateTrainee_IsWorking()
    {
        var traineeCountBefore = _uow.TraineeRepository.GetAllTraineesAsync()
            .Result
            .Count();
        var newTrainee = new Trainee() { FirstName = "FirstName4", LastName = "LastName4" };
        
        _uow.TraineeRepository.CreateTrainee(newTrainee);
        _uow.SaveAsync().Wait();

        var traineeCountAfter = _uow.TraineeRepository.GetAllTraineesAsync()
            .Result
            .Count();
        Assert.That(traineeCountBefore + 1, Is.EqualTo(traineeCountAfter));
    }

    [Test]
    public void GetTraineeByIdAsync_IsWorking()
    {
        const int traineeId = 1;
        var trainee = _uow.TraineeRepository.GetTraineeByIdAsync(traineeId).Result!;            
        Assert.That(trainee.Id, Is.EqualTo(traineeId));
        Assert.That(trainee.FirstName, Is.EqualTo("FirstName1"));
    }

    [Test]
    public void UpdateTrainee_IsWorking()
    {
        var newTrainee = new Trainee() { Id = 4, FirstName = "FirstName4", LastName = "LastName4" };
        
        _uow.TraineeRepository.CreateTrainee(newTrainee);
        _uow.SaveAsync().Wait();


        var result = _uow.TraineeRepository.GetTraineeByIdAsync(4).Result!;
        result.FirstName = "FirstName4_updated";
        _uow.TraineeRepository.UpdateTrainee(result);
        _uow.SaveAsync().Wait();

        Assert.That(result.FirstName, Is.EqualTo("FirstName4_updated"));
    }

   [Test]
    public void DeleteTrainee_IsWorking()
    {
        const int traineeId = 1;
        var traineeCountBefore = _uow.TraineeRepository.GetAllTraineesAsync()
            .Result
            .Count();
        var trainee = _uow.TraineeRepository.GetTraineeByIdAsync(traineeId).Result!;
        
        _uow.TraineeRepository.RemoveTrainee(trainee);
        _uow.SaveAsync().Wait();
        
        var traineeCountAfter = _uow.TraineeRepository.GetAllTraineesAsync()
            .Result
            .Count();

        Assert.That(traineeCountBefore - 1, Is.EqualTo(traineeCountAfter));
    }
}
