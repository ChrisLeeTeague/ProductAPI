using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    public class GetProduct : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
