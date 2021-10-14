using System.ComponentModel.DataAnnotations;

namespace api.Models.Users
{
  public class RegisterViewModelInput
  {
    [Required(ErrorMessage = "O nome de usuário é obrigatório")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatório")]
    public string Password { get; set; }
  }
}