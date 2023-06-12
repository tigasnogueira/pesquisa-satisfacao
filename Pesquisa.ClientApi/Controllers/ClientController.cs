using Microsoft.AspNetCore.Mvc;

namespace Pesquisa.ClientApi.Controllers;

public class ClientController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }
}
