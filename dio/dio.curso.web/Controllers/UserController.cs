using System;
using Microsoft.AspNetCore.Mvc;
using dio.curso.web.Models.User;
using dio.curso.web.Services;
using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace dio.curso.web.Controllers
{
  public class UserController : Controller
  {
    private readonly IUserService _iUserService;
    public UserController(IUserService iUserService)
    {
      _iUserService = iUserService;
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModelInput newUserData)
    {
      try
      {
        var user = await _iUserService.Register(newUserData);

        ModelState.AddModelError("", "Os dados foram cadastrados com sucesso");
      }
      catch (ApiException ex)
      {
        ModelState.AddModelError("", ex.Message);
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
      }

      return View();
    }

    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModelInput loginData)
    {
      try
      {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        var user = await _iUserService.Login(loginData);

        var claims = new List<Claim> 
        {
          new Claim(ClaimTypes.NameIdentifier, user.Details.Code.ToString()),
          new Claim(ClaimTypes.Name, user.Details.Login),
          new Claim(ClaimTypes.Email, user.Details.Email),
          new Claim("token", user.Token),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties 
        {
          ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddDays(1))
        };

        ModelState.AddModelError("", "Login efetuado com sucesso");
      }
      catch (ApiException ex)
      {
        ModelState.AddModelError("", ex.Message);
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
      }

      return View();
    }

    public IActionResult ActLogoff() {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Logoff() {
      return RedirectToAction($"{nameof(Login)}");
    }
  }
}