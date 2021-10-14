using System.ComponentModel.DataAnnotations;

namespace mvc_web.Models.User
{
  public class RegisterUserViewModelInput
  {
    [Required(ErrorMessage = "O nome de usuário é obrigatório")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatório")]
    public string Password { get; set; }
  }
}