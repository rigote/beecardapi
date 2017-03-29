using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeeCard.Application.Interfaces;

namespace BeeCard.Tests
{
    [TestClass]
    public class UserTest : BaseTest
    {
        [TestMethod]
        public void CreateUserTest()
        {
            var userService = container.GetInstance<IUserAppService>();
            var user = userService.GetUserByEmail("ricardo.ghion@gmail.com");

            if (user == null)
            {
                userService.RegisterUser("ricardo.ghion@gmail.com", "Ricardo", "Fermino", "123456", new DateTime(1986, 11, 14), "5511980643842", null, null);
            }
        }

        [TestMethod]
        public void FindUserTest()
        {
            var userService = container.GetInstance<IUserAppService>();
            var user = userService.FindUser("ricardo.ghion@gmail.com", "123456").Result;            

            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ChangePasswordTest()
        {
            var userService = container.GetInstance<IUserAppService>();

            var user = userService.GetUserByEmail("ricardo.ghion@gmail.com");

            if (user != null)
            {
                userService.ChangePassword(user.Id, "1234567", "123456");
            }

        }
    }
}
