using Microsoft.AspNetCore.Mvc;

namespace KinderGartenManagerV2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult HomePage()
        {
            return View();
        }
    }
}
