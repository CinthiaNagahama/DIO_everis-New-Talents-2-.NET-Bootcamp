using System.ComponentModel.DataAnnotations;

namespace mvc_web.Models.User
{
  public class LoginViewModelOutput
  {
    public string Token { get; set; }
    public LoginViewModelOutputDetails Details { get; set; }
  }

  public class LoginViewModelOutputDetails
  {
    public int Code { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
  }
}