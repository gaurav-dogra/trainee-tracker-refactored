using Microsoft.EntityFrameworkCore;
using Trainee_Tracker.Domain.Models;

namespace Trainee_Tracker.Models.Data;

public static class SeedData
{
    private static void SeedTrainers(ApplicationDbContext db)
    {
        if (db.Trainers.Any())
        {
            return;   // DB has been seeded
        }

        db.Trainers.AddRange(

               new Trainer
               {
                   FirstName = "Nish",
                   LastName = "Mandal",
                   Email = "nish@nish.com",
                   CourseId = 1
               },
               new Trainer
               {
                   FirstName = "Cathy",
                   LastName = "French",
                   Email = "cfrench@span.com",
                   CourseId = 3
               },
               new Trainer
               {
                   FirstName = "Martin",
                   LastName = "Beard",
                   Email = "mbeard@spar.com",
                   CourseId = 2
               },
               new Trainer
               {
                   FirstName = "Nick",
                   LastName = "Reed",
                   Email = "nk@redd.com",
                   CourseId = 4
               },
               new Trainer
               {
                   FirstName = "Tim",
                   LastName = "McCarthy",
                   Email = "tim@carthy.com",
                   CourseId = 5
               },
               new Trainer
               {
                   FirstName = "Mitch",
                   LastName = "Diego",
                   Email = "mitch@nish.com",
                   CourseId = 6
               });
        db.SaveChanges();
    }

    private static void SeedTrainees(ApplicationDbContext db)
    {
        if (db.Trainees.Any())
        {
            return;   // DB has been seeded
        }

        db.Trainees.AddRange(

               new Trainee
               {
                   FirstName = "Joe",
                   LastName = "Bloggs",
                   Email = "joebloggs@email.com",
                   CourseId = 6
               },
               new Trainee
               {
                   FirstName = "Orlando",
                   LastName = "Bloom",
                   Email = "Oblooms@email.com",
                   CourseId = 6
               },
               new Trainee
               {
                   FirstName = "John",
                   LastName = "Smith",
                   Email = "jsmiths@email.com",
                   CourseId = 5
               },
               new Trainee
               {
                   FirstName = "Cherry",
                   LastName = "Pies",
                   Email = "Cherrypies@email.com",
                   CourseId = 4
               },
               new Trainee
               {
                   FirstName = "Yin",
                   LastName = "Yang",
                   Email = "yys@email.com",
                   CourseId = 4
               },
               new Trainee
               {
                   FirstName = "Martin",
                   LastName = "Farm",
                   Email = "mfarm@email.com",
                   CourseId = 4
               },
               new Trainee
               {
                   FirstName = "Borris",
                   LastName = "Johnsmith",
                   Email = "bjs1@email.com",
                   CourseId = 4
               },
               new Trainee
               {
                   FirstName = "Mo",
                   LastName = "Bamba",
                   Email = "mBamba@nba.com",
                   CourseId = 3
               },
               new Trainee
               {
                   FirstName = "Shaquille",
                   LastName = "O'Neil",
                   Email = "sneil@nba.com",
                   CourseId = 3
               },
               new Trainee
               {
                   FirstName = "Lisa",
                   LastName = "Bert",
                   Email = "Lbert@email.com",
                   CourseId = 2
               },
               new Trainee
               {
                   FirstName = "Stanni",
                   LastName = "Lewis",
                   Email = "s@lew.com",
                   CourseId = 1
               });
        db.SaveChanges();
    }

    private static void SeedCourses(ApplicationDbContext db)
    {
        if (db.Courses.Any())
        {
            return;   // DB has been seeded
        }

        db.Courses.AddRange(

                new Course
                {
                    Name = "Engineering 104"
                },
                new Course
                {
                    Name = "Data 101"
                },
                new Course
                {
                    Name = "Engineering 106"
                },
                new Course
                {
                    Name = "SDET 44"
                },
                new Course
                {
                    Name = "Business 100"
                },
                new Course
                {
                    Name = "DevOps 32"
                });
        db.SaveChanges();
    }

    private static void SeedTrackers(ApplicationDbContext db)
    {
        if (db.Trackers.Any())
        {
            return;
        }

        db.Trackers.AddRange(

            new Tracker
            {
                WeekNumber = 1,
                StartDoing = "I want to start making my database work",
                StopDoing = "I want to stop duplicating my data",
                ContinueDoing = "Working well with my team",
                TechSkills = SkillLevelEnums.PartiallySkilled,
                ConsultancySkills = SkillLevelEnums.Skilled,
                TraineeId = 1
            },
            new Tracker
            {
                WeekNumber = 2,
                StartDoing = "I want to start writing unit tests",
                StopDoing = "Test last development",
                ContinueDoing = "Learning about databases",
                TechSkills = SkillLevelEnums.PartiallySkilled,
                ConsultancySkills = SkillLevelEnums.Unskilled,
                TraineeId = 1
            },
            new Tracker
            {
                WeekNumber = 1,
                StartDoing = "Making seed data",
                StopDoing = "Communicating poorly",
                ContinueDoing = "Improving my developer skills",
                TechSkills = SkillLevelEnums.PartiallySkilled,
                ConsultancySkills = SkillLevelEnums.Skilled,
                TraineeId = 2
            });
        db.SaveChanges();
    }
}
