using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;
using Trainee_Tracker.Repository;

namespace TrackerTests.RepositoryTests;

public class CourseRepositoryTests
{
    private ApplicationDbContext _context = null!;
    private CourseRepository _sut = null!;

    [OneTimeSetUp]
    public void Init()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemory").Options;
        _context = new ApplicationDbContext(options);
        _sut = new CourseRepository(_context);
    }

    [SetUp]
    public void Setup()
    {
        TestsSeedData.CourseList
            .ForEach(_sut.CreateCourse);
    }

    [TearDown]
    public void TearDown()
    {
        TestsSeedData.CourseList
            .ForEach(_sut.RemoveCourse);
    }

    [Test]
    public void CourseRepository_SuccessfulConstruction()
    {
        Assert.That(_sut, Is.InstanceOf<CourseRepository>());
    }

    [Test]
    public void GetAllCoursesAsync_IsWorking()
    {
        var result = _sut.GetAllCoursesAsync()
            .Result
            .Count();
        const int courseSeedDataSize = 3;
        Assert.That(result, Is.EqualTo(courseSeedDataSize));
    }

    [Test]
    public void CreateCourse_IsWorking()
    {
        var courseCountBefore = _sut.GetAllCoursesAsync()
            .Result
            .Count();
        var newCourse = new Course() { Name = "newCourse" };
        _sut.CreateCourse(newCourse);
        var courseCountAfter = _sut.GetAllCoursesAsync()
            .Result
            .Count();
        Assert.That(courseCountBefore + 1, Is.EqualTo(courseCountAfter));
    }

    [Test]
    public void GetCourseByIdAsync_IsWorking()
    {
        const int courseId = 1;
        var result = _sut.GetCourseByIdAsync(courseId).Result!;
        Assert.That(result.Id, Is.EqualTo(courseId));
        Assert.That(result.Name, Is.EqualTo("CourseName"));
    }

    [Test]
    public void UpdateCourse_IsWorking()
    {
        var newCourse = new Course() { Name = "NewCourse" };
        _sut.CreateCourse(newCourse);

        var result = _sut.GetCourseByIdAsync(4).Result!;
        result.Name = "NewCourse_updated";
        _sut.UpdateCourse(result);

        Assert.That(result.Name, Is.EqualTo("NewCourse_updated"));
    }

    [Test]
    public void Delete_IsWorking()
    {
        const int courseId = 1;
        var courseCountBefore = _sut.GetAllCoursesAsync().Result.Count();
        var course = _sut.GetCourseByIdAsync(courseId).Result!;

        _sut.RemoveCourse(course);

        var courseCountAfter = _sut.GetAllCoursesAsync().Result.Count();
        Assert.That(courseCountBefore - 1, Is.EqualTo(courseCountAfter));
    }
}
