using Microsoft.AspNetCore.Mvc;

namespace SampleStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
