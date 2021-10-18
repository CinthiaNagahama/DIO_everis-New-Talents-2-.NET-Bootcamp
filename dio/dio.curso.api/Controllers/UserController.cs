using Microsoft.AspNetCore.Mvc;
using api.Models.Users;
using api.Models;
using Swashbuckle.AspNetCore.Annotations;
using curso.api.Filters;
using api.Business.Entities;
using api.Business.Repositories;
using api.Configurations;

namespace api.Controllers
{
  [Route("api/v1/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserRepository _userRepository;

    private readonly IAuthenticationService _authenticationService;

    public UserController(
      IUserRepository userRepository,
      IAuthenticationService authenticationService
    )
    {
      _userRepository = userRepository;
      _authenticationService = authenticationService;
    }

    /// <summary>
    /// Este serviço permite autenticar um usuário cadastrado e ativo
    /// </summary>
    /// <param name="loginViewModelInput">View model do login</param>
    /// <returns>Retorna status ok, dados do usuário e o token em caso de sucesso</returns>
    [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", Type = typeof(LoginViewModelInput))]
    [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(CheckFieldViewModelOutput))]
    [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
    [HttpPost]
    [Route("login")]
    [ModelStateCustomizedValidation]
    public IActionResult Login(LoginViewModelInput loginViewModelInput)
    {
      var user = _userRepository.GetUser(loginViewModelInput.Login);

      if (user == null)
      {
        return BadRequest("Houve um erro ao tentar acessar");
      }

      // if (user.Password != loginViewModelInput.Password.GenerateCryptografedPassword())
      // {
      //   return BadRequest("Usuário e/ou senha incorretos");
      // }

      var userViewModelOutput = new UserViewModelOutput()
      {
        Code = user.Code,
        Login = loginViewModelInput.Login,
        Email = user.Email
      };

      var token = _authenticationService.GenerateToken(userViewModelOutput);

      return Ok(new
      {
        Token = token,
        Usuario = userViewModelOutput
      });
    }

    /// <summary>
    /// Este serviço permite cadastrar um usuário não existente.
    /// </summary>
    /// <param name="registerViewModelInput">View model do registro de usuário</param>
    [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar", Type = typeof(RegisterViewModelInput))]
    [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", Type = typeof(CheckFieldViewModelOutput))]
    [SwaggerResponse(statusCode: 500, description: "Erro interno", Type = typeof(GenericErrorViewModel))]
    [HttpPost]
    [Route("register")]
    [ModelStateCustomizedValidation]
    public IActionResult Register(RegisterViewModelInput registerViewModelInput)
    {

      // var pendingMigrations = context.Database.GetPendingMigrations();
      // if (pendingMigrations.Count() > 0)
      // {
      //   context.Database.Migrate();
      // }

      var user = new User();
      user.Login = registerViewModelInput.Login;
      user.Email = registerViewModelInput.Email;
      user.Password = registerViewModelInput.Password;
      _userRepository.Add(user);
      _userRepository.Commit();

      return Created("", registerViewModelInput);
    }
  }
}