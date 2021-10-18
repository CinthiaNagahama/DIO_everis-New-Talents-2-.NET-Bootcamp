using System.ComponentModel.DataAnnotations;

namespace dio.curso.web.Models.Course
{
  public class RegisterCourseViewModelOutput
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Login { get; set; }
  }
}