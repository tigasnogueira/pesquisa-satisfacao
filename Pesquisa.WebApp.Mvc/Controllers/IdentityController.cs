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
    private readonly Interfaces.IAuthenticationService _autenticationService;

    public IdentityController(Interfaces.IAuthenticationService autenticationService)
    {
        _autenticationService = autenticationService;
    }

    [HttpGet]
    [Route("nova-conta")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [Route("nova-conta")]
    public async Task<IActionResult> Register(UserRegister registerUserViewModel)
    {
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
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UserLogin userLogin, string returnUrl = null)
    {
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
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }

    private async Task PerformLogin(UserResponseLogin response)
    {
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
        if (token.Contains("Bearer")) return token.Replace("Bearer ", "");

        return token;
    }
}
