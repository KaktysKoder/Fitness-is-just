using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitnes_is_just.BL.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using Fitnes_is_just.BL.Model;
using System.Linq;

namespace Fitnes_is_just.BL.Controller.Tests
{
    [TestClass()]
    public class ExerciesControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController     = new UserController(userName);
            var exerciesController = new  ExerciesController(userController.CurrentUser);

            var activity = new Activity(activityName, rnd.Next(10, 50));


            exerciesController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            Assert.AreEqual(activity.Name, exerciesController.Activity.First().Name);
        }
    }
}