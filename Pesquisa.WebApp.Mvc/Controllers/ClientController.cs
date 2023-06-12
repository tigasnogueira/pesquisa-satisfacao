using Microsoft.AspNetCore.Mvc;

namespace Pesquisa.WebApp.Mvc.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
