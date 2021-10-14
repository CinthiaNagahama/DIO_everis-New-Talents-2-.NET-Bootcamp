using mvc_web.Models.Course;
using System.Threading.Tasks;
using Refit;

namespace mvc_web.Services
{
  public interface ICourseService
  {
    [Post("/api/v1/courses")]
    Task<RegisterCourseViewModelOutput> Register(RegisterCourseViewModelInput registerCourseViewModelInput);
  }
}