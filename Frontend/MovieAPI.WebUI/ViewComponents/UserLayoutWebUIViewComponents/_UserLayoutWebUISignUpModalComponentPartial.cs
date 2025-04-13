using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.WebUI.ViewComponents.UserLayoutWebUIViewComponents
{
    public class _UserLayoutWebUISignUpModalComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
