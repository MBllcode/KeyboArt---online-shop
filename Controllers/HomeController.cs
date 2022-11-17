using Microsoft.AspNetCore.Mvc;

namespace KeyboArt.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
