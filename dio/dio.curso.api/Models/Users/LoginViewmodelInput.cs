using System.ComponentModel.DataAnnotations;

namespace api.Models.Users
{
  public class LoginViewModelInput
  {
    [Required(ErrorMessage = "O nome de usuário é obrigatório")]
    public string Login { get; set; }

    [Required(ErrorMessage = "A senha é obrigatório")]
    public string Password { get; set; }
  }
}