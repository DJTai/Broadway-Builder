﻿using System;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Services;

namespace ServiceLayer.Test
{
    [TestClass]
    public class TheaterJobPostingTest
    {
        [TestMethod]
        public void TheaterJobService_CreateTheaterJobPosting_Pass()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var theaterJobService = new TheaterJobPostingService(dbcontext);
            var expected = true;
            var actual = false;
            
            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            theaterService.CreateTheater(theater);
            dbcontext.SaveChanges();
            var jobPosting = new TheaterJobPosting(theater.TheaterID,"intern","some decription","title","hours","some requirements", "testType");
            //Act
            theaterJobService.CreateTheaterJob(jobPosting);
            var results = dbcontext.SaveChanges();
            if(results > 0)
            {
                actual = true;
            }

            theaterJobService.DeleteTheaterJob(jobPosting.HelpWantedID);
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            //Assert 
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void TheaterJobService_ShouldNotCreateSameTheaterJob()
        //{
        //    //Arrange
        //    var dbcontext = new BroadwayBuilderContext();
        //    var theaterService = new TheaterService(dbcontext);
        //    var theaterJobService = new HelpWantedService(dbcontext);
        //    var expected = true;
        //    var actual = false;

        //    var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
        //    theaterService.CreateTheater(theater);
        //    dbcontext.SaveChanges();
        //    var jobPosting = new TheaterJobPosting(theater.TheaterID, "intern", "some decription", "title", "hours", "some requirements", "testType");
        //    theaterJobService.CreateTheaterJob(jobPosting);
        //    dbcontext.SaveChanges();
        //    //Act
        //    try
        //    {
        //        theaterJobService.CreateTheaterJob(jobPosting);
        //        dbcontext.SaveChanges();
        //    }
        //    catch
        //    {
        //        actual = true;
        //    }
        //    theaterService.DeleteTheater(theater);
        //    dbcontext.SaveChanges();
        //    //Assert
        //    Assert.AreEqual(expected, actual);

        //    //theaterJobService.DeleteTheaterJob(jobPosting);
        //    //theaterService.DeleteTheater(theater);
        //    //dbcontext.SaveChanges();
        //}

        [TestMethod]
        public void TheaterJobService_DeleteTheaterJobPosting_Pass()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var theaterJobService = new TheaterJobPostingService(dbcontext);
            var expected = true;
            var actual = false;

            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");
            
            var jobPosting = new TheaterJobPosting(theater.TheaterID, "intern", "some decription", "title", "hours", "some requirements", "testType");
            //Act
            theaterService.CreateTheater(theater);
            //dbcontext.SaveChanges();
            theaterJobService.CreateTheaterJob(jobPosting);
            dbcontext.SaveChanges();
            theaterJobService.DeleteTheaterJob(jobPosting.HelpWantedID);
            var results = dbcontext.SaveChanges();
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();
            if (results > 0)
            {
                actual = true;
            }
            //Assert 
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TheaterJobService_ReadTheaterJobPosting_Pass()
        {
            //Arrange
            var dbcontext = new BroadwayBuilderContext();
            var theaterService = new TheaterService(dbcontext);
            var theaterJobService = new TheaterJobPostingService(dbcontext);
            var expected = true;
            var actual = false;

            var theater = new Theater("someTheater", "Regal", "theater st", "LA", "CA", "US", "323323");

            var jobPosting = new TheaterJobPosting(theater.TheaterID, "intern", "some decription", "title", "hours", "some requirements", "testType");
            //Act
            theaterService.CreateTheater(theater);
            theaterJobService.CreateTheaterJob(jobPosting);
            dbcontext.SaveChanges();
            TheaterJobPosting getTheaterJob = theaterJobService.GetTheaterJob(jobPosting);
            if (getTheaterJob != null)
            {
                actual = true;
            }
            theaterJobService.DeleteTheaterJob(jobPosting.HelpWantedID);
            dbcontext.SaveChanges();
            theaterService.DeleteTheater(theater);
            dbcontext.SaveChanges();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
