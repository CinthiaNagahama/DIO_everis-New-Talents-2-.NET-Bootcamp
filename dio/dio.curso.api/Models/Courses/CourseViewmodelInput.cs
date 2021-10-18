using System.ComponentModel.DataAnnotations;

namespace api.Models.Courses
{
  public class CourseViewModelInput
  {
    [Required(ErrorMessage = "O nome do curso é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A descrição do curso é obrigatória")]
    public string Description { get; set; }
  }
}