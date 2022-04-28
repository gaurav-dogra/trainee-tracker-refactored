//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;
//using Trainee_Tracker.Controllers;
//using Trainee_Tracker.Models;

//namespace Tracker_Tests
//{
//    public class TrackerControllerTests
//    {
//        private ApplicationDbContext _context;
//        private TrackersController _sut;

//        [OneTimeSetUp]
//        public void Init()
//        {
//            //InMemoryDatabase           
//            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "MemoryDb").Options;
//            _context = new ApplicationDbContext(options);
//            _sut = new TrackersController(_context);

//            var courseTest = new Course
//            {
//                CourseId = 1,
//                Name = "TestCourse",
//                Trainees = { new Trainee { Id = 3 } },
//                Trainers = { new Trainer { Id = 4 } },
//            };

//            var WeekTracker = new Tracker { TrackerId = 2, TraineeId = 5 };
//            var traineeTest = new Trainee
//            {

//                Id = 1,
//                FirstName = "TestFName",
//                LastName = "TestLName",
//                Email = "TestEmail@Trainee.com",
//                //image
//                CourseId = courseTest.CourseId,
//                Course = courseTest,
//                WeekNumberAndTracker =
//                {
//                    {12, WeekTracker}

//                },
//            };

//            var traineeTrackerTest = new Tracker
//            {
//                //Enum values= { "UNSKILLED", LOW_SKILLED, PARTIALLY_SKILLED, SKILLED }

//                TrackerId = 1,
//                WeekNumber = 1,
//                ContinueDoing = "I will continue to do this",
//                StartDoing = "I will start doing this",
//                StopDoing = "I will stop doing this",
//                TechSkills = SkillLevelEnums.SKILLED,
//                ConsultancySkills = SkillLevelEnums.UNSKILLED,
//                TraineeId = 1,
//                Trainee = traineeTest,
//            };

//            _context.SaveChanges();
//        }

//        [Test]
//        public void test()
//        {
//            Assert.That(1, Is.EqualTo(1));
//        }
//        //[Test]
//        //public void WhenCreatingANewTrackerItShouldBeSuccesfullyCreated()
//        //{
//        //    int numBefore = _context.TrackerListTest.Count();
//        //    var trainee2 = new Trainee
//        //    {
//        //        FirstName = "FirstName2",
//        //        LastName = "LastName2",
//        //        Id = 2,
//        //    };

//        //    var newTracker = new Tracker
//        //    {
//        //        Id = trainee2.Id,
//        //        ContinueDoing = "I will continue to do this 2",
//        //        StartDoing = "I will start doing this 2",
//        //        StopDoing = "I will stop doing this 2",
//        //        WeekNumber = 1,
//        //    };

//        //    _context.SaveChanges(newTracker);
//        //    Assert.That(numBefore + 1, Is.EqualTo(_context.TrackerListTest.Count()));
//        //}

//        //[TearDown]
//        //public void TearDown()
//        //{
//            //Find a function to clear all items from _sut
//            //_context.Dispose();
            

//        //}

//    }
//}
