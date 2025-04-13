using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult MovieList()
        {
            ViewBag.v1 = "Film Listesi";
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v1 = "Tüm Filmler";
            return View();
        }
    }
}
