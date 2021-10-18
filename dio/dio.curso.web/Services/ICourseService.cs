using dio.curso.web.Models.Course;
using System.Threading.Tasks;
using Refit;
using System.Collections.Generic;

namespace dio.curso.web.Services {
  public interface ICourseService {
    [Post("/api/v1/courses")]
    [Headers("Authorization: Bearer")]
    Task<RegisterCourseViewModelOutput> Register(RegisterCourseViewModelInput registerCourseViewModelInput);

    [Get("/api/v1/courses")]
    [Headers("Authorization: Bearer")]
    Task<IList<ListCoursesViewModelOutput>> Get();
  }
}
