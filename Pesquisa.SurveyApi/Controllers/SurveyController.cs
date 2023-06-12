using Microsoft.AspNetCore.Mvc;

namespace Pesquisa.SurveyApi.Controllers;

public class SurveyController : Controller
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
