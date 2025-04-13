using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
    public class _UserLayoutWebUIHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
