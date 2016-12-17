using BeeCard.Application.Interfaces;
using System.Web.Mvc;

namespace BeeCard.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestAppService _testService;
        public HomeController(ITestAppService testService)
        {
            _testService = testService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            _testService.DoTest();

            return View();
        }
    }
}
