using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
    public class _UserLayoutWebUILoginModalComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
