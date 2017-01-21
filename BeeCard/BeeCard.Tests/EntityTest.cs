using BeeCard.Application.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeeCard.Tests
{
    [TestClass]
    public class EntityTest : BaseTest
    {       
        [TestMethod]
        public void TestConnection()
        {            
            var userService = container.GetInstance<IUserAppService>();
            var result = userService.GetAll();
        }
    }
}
