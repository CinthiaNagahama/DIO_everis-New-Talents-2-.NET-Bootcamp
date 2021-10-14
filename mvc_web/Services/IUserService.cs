using mvc_web.Models.User;
using System.Threading.Tasks;
using Refit;

namespace mvc_web.Services
{
  public interface IUserService
  {
    [Post("/api/v1/user/register")]
    Task<RegisterUserViewModelInput> Register(RegisterUserViewModelInput registerUserViewModelInput);

    [Post("/api/v1/user/login")]
    Task<LoginViewModelOutput> Login(LoginViewModelInput loginViewModelInput);
  }
}