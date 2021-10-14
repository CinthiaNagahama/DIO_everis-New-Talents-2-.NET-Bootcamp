using System;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using mvc_web.Models.User;
using Newtonsoft.Json;
using mvc_web.Services;
using Refit;
using System.Threading.Tasks;

namespace mvc_web.Controllers
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
      /* Without using Refit */
      // var httpClient = new HttpClient();
      // httpClient.BaseAddress = new Uri("https://localhost:5001/");

      // var httpPost = httpClient.PostAsync(
      //   "/api/v1/user/register",
      //   new StringContent(JsonConvert.SerializeObject(newUserData), Encoding.UTF8, "application/json")
      // ).GetAwaiter().GetResult();

      // if (httpPost.StatusCode == System.Net.HttpStatusCode.Created)
      // {
      //   ModelState.AddModelError("", "Os dados foram cadastrados com sucesso");
      // }
      // else
      // {
      //   ModelState.AddModelError("", "Erro ao cadastrar");
      // }

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
        var user = await _iUserService.Login(loginData);

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
  }
}