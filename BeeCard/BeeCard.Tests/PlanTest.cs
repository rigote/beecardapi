using BeeCard.Application.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BeeCard.Tests
{
    [TestClass]
    public class PlanTest : BaseTest
    {

        [TestMethod]
        public void CreatePlanTest()
        {
            var planService = container.GetInstance<IPlanAppService>();

            var plans = planService.GetPlans(null, null).Item2;

            if (!plans.TrueForAll(c => c.Name.Contains("Bronze")))
                planService.CreatePlan("Plano Bronze", "Plano bronze destinado a xibilobas'");
            else
                Assert.IsNull(plans);
        }


        [TestMethod]
        public void RemovePlanTest()
        {
            var planService = container.GetInstance<IPlanAppService>();

            var plan = planService.GetPlans(null, null).Item2.FirstOrDefault();

            if(plan != null)
                planService.RemovePlan(plan.ID);
        }
    }
}
