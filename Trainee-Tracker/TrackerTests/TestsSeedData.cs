using System.Collections.Generic;
using Trainee_Tracker.Domain.Models;
using Trainee_Tracker.Models;

namespace TrackerTests;

public static class TestsSeedData
{
    public static List<Course> CourseList { get; } = new()
    {
        new Course()
        {
            Name = "CourseName"
        }
    };

    public static List<Trainee> TraineeList { get; } = new()
    {
        new Trainee()
        {
            FirstName = "FirstName1",
            LastName = "LastName1",
            Email = "test@test.com",
            CourseId = 1
        },

        new Trainee()
        {
            FirstName = "FirstName2",
            LastName = "LastName2",
            Email = "test2@test.com",
            CourseId = 1
        },

        new Trainee()
        {
            FirstName = "FirstName3",
            LastName = "LastName3",
            Email = "test3@test.com",
            CourseId = 1
        }
    };

    public static List<Tracker> TrackerList { get; } = new()
    {
        new Tracker()
        {
            WeekNumber = 1,
            StartDoing = "Start doing week 1",
            StopDoing = "Stop doing week 1",
            ContinueDoing = "Continue doing week 1",
            TechSkills = SkillLevelEnums.Skilled,
            ConsultancySkills = SkillLevelEnums.PartiallySkilled,
            TraineeId = 1
        }, 
        new Tracker()
        {
            WeekNumber = 2,
            StartDoing = "Start doing week 2",
            StopDoing = "Stop doing week 2",
            ContinueDoing = "Continue doing week 2",
            TechSkills = SkillLevelEnums.Skilled,
            ConsultancySkills = SkillLevelEnums.Skilled,
            TraineeId = 1
        }
    };
}

