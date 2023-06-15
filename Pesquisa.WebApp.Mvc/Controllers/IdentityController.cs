using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Pesquisa.WebApp.Mvc.Interfaces;
using Pesquisa.WebApp.Mvc.Models;
using System.Security.Claims;

namespace Pesquisa.WebApp.Mvc.Controllers;

public class IdentityController : MainController
{
    private readonly ILogger<IdentityController> _logger;
    private readonly Interfaces.IAuthenticationService _autenticationService;

    public IdentityController(ILogger<IdentityController> logger, Interfaces.IAuthenticationService autenticationService) : base(logger)
    {
        _logger = logger;
        _autenticationService = autenticationService;
    }

    [HttpGet]
    [Route("nova-conta")]
    public IActionResult Register()
    {
        _logger.LogInformation("Register page selected");

        return View();
    }

    [HttpPost]
    [Route("nova-conta")]
    public async Task<IActionResult> Register(UserRegister registerUserViewModel)
    {
        _logger.LogInformation("Register page loaded");

        if (!ModelState.IsValid) return View(registerUserViewModel);

        var response = await _autenticationService.Register(registerUserViewModel);

        if (ResponseHasErrors(response.ResponseResult)) return View(registerUserViewModel);

        await PerformLogin(response);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    [Route("login")]
    public IActionResult Login(string returnUrl = null)
    {
        _logger.LogInformation("Login page selected");

        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
    {
        _logger.LogInformation("Login page loaded");

        ViewData["ReturnUrl"] = returnUrl;
        //if (!ModelState.IsValid) return View(usuarioLogin);

        var ListErro = ModelState.Where(a => a.Value.ValidationState == ModelValidationState.Invalid).Select(a => a.Key + " " + a.Value.Errors[0].ErrorMessage).ToList();

        var response = await _autenticationService.Login(userLogin);

        if (ResponseHasErrors(response.ResponseResult)) return View(userLogin);

        await PerformLogin(response);

        if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");

        return LocalRedirect(returnUrl);
    }

    [HttpGet]
    [Route("sair")]
    public async Task<IActionResult> Logout()
    {
        _logger.LogInformation("Logout page loaded");

        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    private async Task PerformLogin(UserResponseLogin response)
    {
        _logger.LogInformation("Performing login");

        var token = GetFormattedToken(response.AccessToken);

        var claims = new List<Claim>();
        claims.Add(new Claim("JWT", response.AccessToken));

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
            IsPersistent = true
        };

        await HttpContext.SignInAsync(
                       CookieAuthenticationDefaults.AuthenticationScheme,
                                  new ClaimsPrincipal(claimsIdentity),
                                             authProperties);
    }

    private string GetFormattedToken(string token)
    {
        _logger.LogInformation("Getting formatted token");

        if (token.Contains("Bearer")) return token.Replace("Bearer ", "");

        return token;
    }
}
