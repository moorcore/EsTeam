using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EsTeam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private EsTeamAppDBContext db;

        public HomeController(ILogger<HomeController> logger, EsTeamAppDBContext context)
        {
            _logger = logger;
            db = context;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminPanel()
        {
            return View();
        }

        [Authorize]
        public ActionResult EmployeePanel()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
