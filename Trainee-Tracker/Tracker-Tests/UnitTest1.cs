using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Tracker_Tests
{
    //This will be deleted later when Trainee is implemented - Use to create basic CRUD testing
    public class Trainee
    {
        public string FirstName;
        public string LastName;
        public int Id;
        public Dictionary<int, Tracker> Weeks;


    }
    public class Tracker
    {
        public int Id;
        public string ContinueDoing;
        public string StartDoing;
        public string StopDoing;
        public int WeekNumber;
    }
    public class Database
    {
        public List<Tracker> TrackerListTest;
        //public Database _database;
        public Database()
        {
            TrackerListTest = new List<Tracker>();
        }
        public void SaveChanges(Tracker t)
        {
            // Equivalent to SaveChanges(); | Add tracker to the database

            TrackerListTest.Add(t);
        }
    }

    public class Tests : Trainee
    {
        //Base
        //private InsertServiceLayerHere _sut;
        //private InsertDbContextHere _context;

        private Database db;

        [SetUp]
        public void Setup()
        {
            //InMemoryDatabase           
            //var options = new DbContextOptionsBuilder<InsertDbContextHere>().UseInMemoryDatabase(databaseName: "MemoryDb").Options;
            //_context = new InsertDbContextHere(options);
            //_sut = new InsertServiceLayerHere(_context);

            db = new Database();

            var traineeTrackerTest = new Tracker
            {
                Id = 1,
                ContinueDoing = "I will continue to do this",
                StartDoing = "I will start doing this",
                StopDoing = "I will stop doing this",
                WeekNumber = 1,

            };
            var traineeTest = new Trainee
            {
                FirstName = "TestFName",
                LastName = "TestLName",
                Id = 1,
                // Weeks = (1, traineeTrackerTest)
            };

            db.SaveChanges(traineeTrackerTest);

        }

        //HAPPY PATHS - TRAINEE 
        //Test 1.0
        [Test]
        public void CorrectConstruction()
        {
            //Assert.That(_sut, Is.InstanceOf< Correct Instance >());
        }



        //HAPPY PATHS - TRAINEE 
        //Test 1.1
        [Test]
        public void WhenCreatingANewTrackerItShouldBeSuccesfullyCreated()
        {
            int numBefore = db.TrackerListTest.Count();
            var trainee2 = new Trainee
            {
                FirstName = "FirstName2",
                LastName = "LastName2",
                Id = 2,
            };

            var newTracker = new Tracker
            {
                Id = trainee2.Id,
                ContinueDoing = "I will continue to do this 2",
                StartDoing = "I will start doing this 2",
                StopDoing = "I will stop doing this 2",
                WeekNumber = 1,
            };

            db.SaveChanges(newTracker);
            Assert.That(numBefore + 1, Is.EqualTo(db.TrackerListTest.Count()));
        }

        //Test 1.2
        [Test]
        public void TraineeCanEditTrackerAndSaveChanges()
        {
            //Implement the CRUD edit function for a role Trainee
            var trainee = db.TrackerListTest[0];
            // var tracker = trainee.Weeks.Value;
            //tracker.
            //Trainee.Edit()?

        }

        //Test 1.3
        [Test]
        public void UserCanOnlySeeTheirTracker()
        {

        }

    }
}

// Make an InMemory Database and filled it with dummydata(that requires the controller to work)

//---1. TRAINEE CRUD | Happy paths---
// 1.0 Test that correct instance of _sut is made 
// 1.1 Test for making sure a new Tracker object is created - use a count test - CREATE
// 1.2 Test for making sure Tracker object can be edited by role Trainee - Save a string, edit the string, then compare e.g. Tracker.StartDoing - UPDATE
// 1.3 Test for making sure a specific User can only see their Tracker - using TrackerID - READ

//---2. TRAINEE CRUD | Sad paths---
// 2.1 Test for making sure the Tracker object is not able to be deleted and removed from the database - DELETE - NOT NEEDED?

//---3. TRAINER CRUD | Happy paths---
// 3.1 Test for making sure that Tracker object is deletable and removed from the database - DELETE
// 3.2 Test for making sure that the correct Trainee details are showed when Trainer clicks specific trainee - READ
// 3.3 Test for making sure a specific Trainee is displayed when using search function - READ

//---4. Testing Controller| Happy path---
// 4.1 Test that view displayes correct http page
// 4.2 Test that edit changes data for either start/stop/continue