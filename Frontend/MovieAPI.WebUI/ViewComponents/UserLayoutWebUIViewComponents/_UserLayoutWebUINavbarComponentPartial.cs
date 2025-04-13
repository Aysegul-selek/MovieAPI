using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
    public class _UserLayoutWebUINavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
