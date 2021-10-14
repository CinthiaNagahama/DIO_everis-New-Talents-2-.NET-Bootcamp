using api.Models.Users;

namespace api.Configurations
{
  public interface IAuthenticationService
  {
    public string GenerateToken(UserViewModelOutput userViewModelOutput);
  }
}