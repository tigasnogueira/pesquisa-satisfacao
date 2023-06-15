using Microsoft.AspNetCore.Mvc;
using Pesquisa.WebApp.Mvc.Models;

namespace Pesquisa.WebApp.Mvc.Controllers;

public class MainController : Controller
{
    private readonly ILogger _logger;

    public MainController(ILogger<MainController> logger)
    {
        _logger = logger;
    }

    protected bool ResponseHasErrors(ResponseResult response)
    {
        _logger.LogError("Response is null or empty");

        if (response != null && response.Errors.Messages.Any())
        {
            foreach (var message in response.Errors.Messages)
            {
                ModelState.AddModelError(string.Empty, message);
            }

            return true;
        }

        return false;
    }
}
