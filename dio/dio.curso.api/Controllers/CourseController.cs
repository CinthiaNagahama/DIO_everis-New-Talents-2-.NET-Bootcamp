using Microsoft.AspNetCore.Mvc;
using api.Models.Courses;
using System.Threading.Tasks;
using System.Security.Claims;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using api.Business.Repositories;
using api.Business.Entities;
using System.Linq;

namespace api.Controllers
{
  [Route("api/v1/courses")]
  [ApiController]
  [Authorize]
  public class CourseController : ControllerBase
  {
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository)
    {
      _courseRepository = courseRepository;
    }

    /// <summary>
    /// Este serviço permite cadastrar um curso para um usuário autenticado
    /// </summary>
    /// <returns>Retorna status 201 e dados do curso do usuário</returns>
    [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar um curso")]
    [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
    {
      Course course = new Course
      {
        Name = courseViewModelInput.Name,
        Description = courseViewModelInput.Description
      };

      var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
      course.UserCode = userCode;
      _courseRepository.Add(course);
      _courseRepository.Commit();

      return Created("", courseViewModelInput);
    }

    /// <summary>
    /// Este serviço permite obter todos os cursos ativos do usuário.
    /// </summary>
    /// <returns>Retorna status ok e dados do curso do usuário</returns>
    [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter os cursos", Type = typeof(CourseViewModelOutput))]
    [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> Get()
    {
      var userCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

      var courses = _courseRepository.GetByUser(userCode)
        .Select(s => new CourseViewModelOutput()
        {
          Name = s.Name,
          Description = s.Description,
          Login = s.User.Login
        });

      return Ok(courses);
    }
  }
}