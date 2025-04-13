using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
    public class _UserLayoutWebUIPreloaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
