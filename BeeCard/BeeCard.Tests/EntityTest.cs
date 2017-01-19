using BeeCard.Application.Interfaces;
using BeeCard.Utils.DependencyInjection.DependencyResolution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeCard.Tests
{
    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void TestConnection()
        {
            var container = IoC.Initialize();
            var userService = container.GetInstance<IUserAppService>();

            var result = userService.GetAll();
        }
    }
}
