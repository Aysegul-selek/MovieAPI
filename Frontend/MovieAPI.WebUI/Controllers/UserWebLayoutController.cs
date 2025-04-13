using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.Controllers
{
    public class UserWebLayoutController : Controller
    {
        public IActionResult LayoutUI()
        {
            return View();
        }
    }
}
