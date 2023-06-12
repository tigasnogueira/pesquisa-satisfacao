using Microsoft.AspNetCore.Mvc;

namespace Pesquisa.WebApp.Mvc.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
