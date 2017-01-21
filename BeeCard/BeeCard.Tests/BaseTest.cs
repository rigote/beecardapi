using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeeCard.Tests.IoC;
using StructureMap;

namespace BeeCard.Tests
{
    [TestClass]
    public class BaseTest
    {
        public IContainer container;

        public BaseTest()
        {            
            container = DependencyResolver.Container;
        }
    }
}
