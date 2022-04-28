using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;
using Trainee_Tracker.Repository;

namespace TrackerTests.RepositoryTests;

public class TrackerRepositoryTests
{
    private ApplicationDbContext _context = null!;
    private TrackerRepository _sut = null!;

    [OneTimeSetUp]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemory").Options;
        _context = new ApplicationDbContext(options);
        _sut = new TrackerRepository(_context);
    }

    [SetUp]
    public void Setup()
    {
        TestsSeedData.TrackerList
            .ForEach(_sut.CreateTracker);
    }

    [TearDown]
    public void TearDown()
    {
        TestsSeedData.TrackerList
            .ForEach(_sut.RemoveTracker);
    }

    [Test]
    public void TraineesRepository_SuccessfulConstruction()
    {
        Assert.That(_sut, Is.InstanceOf<TrackerRepository>());
    }

    [Test]
    public void GetAllTrackersAsync_IsWorking()
    {
        var result = _sut.GetAllTrackersAsync()
            .Result
            .Count();
        const int trackerSeedDataSize = 2;
        Assert.That(result, Is.EqualTo(trackerSeedDataSize));
    }

    [Test]
    public void CreateTracker_IsWorking()
    {
        var trackerCountBefore = _sut.GetAllTrackersAsync()
            .Result
            .Count();
        var newTracker = new Tracker() { WeekNumber = 3 };
        _sut.CreateTracker(newTracker);
        var traineeCountAfter = _sut.GetAllTrackersAsync()
            .Result
            .Count();
        Assert.That(trackerCountBefore + 1, Is.EqualTo(traineeCountAfter));
    }

    [Test]
    public void GetTrackerByIdAsync_IsWorking()
    {
        const int trackerId = 1;
        var result = _sut.GetTrackersByIdAsync(trackerId).Result!;
        Assert.That(result.Id, Is.EqualTo(trackerId));
        Assert.That(result.StartDoing, Is.EqualTo("Start doing week 1"));
    }

    [Test]
    public void UpdateTracker_IsWorking()
    {
        var newTracker = new Tracker() { WeekNumber = 2, StartDoing = "Start doing update test" };
        _sut.CreateTracker(newTracker);

        var result = _sut.GetTrackersByIdAsync(3).Result!;
        result.StartDoing = "Start doing update test";
        _sut.UpdateTracker(result);

        Assert.That(result.StartDoing, Is.EqualTo("Start doing update test"));
    }

    [Test]
    public void DeleteTracker_IsWorking()
    {
        const int trackerId = 1;
        var trackerCountBefore = _sut.GetAllTrackersAsync().Result.Count();
        var tracker = _sut.GetTrackersByIdAsync(trackerId).Result!;

        _sut.RemoveTracker(tracker);

        var traineeCountAfter = _sut.GetAllTrackersAsync()
            .Result
            .Count();
        Assert.That(trackerCountBefore - 1, Is.EqualTo(traineeCountAfter));
    }
}
