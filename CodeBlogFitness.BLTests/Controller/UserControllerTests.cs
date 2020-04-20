using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        //[TestMethod()]
        //public void UserControllerTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var birtDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            // Act 

            controller.SetNewUserData(gender, birtDate, weight, height);
            var controller2 = new UserController(userName);


            // Assert

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birtDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act

            var controler = new UserController(userName);
            // Assert

            Assert.AreEqual(userName, controler.CurrentUser.Name);
            
        }
    }
}