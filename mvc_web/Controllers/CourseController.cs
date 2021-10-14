using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_web.Models.Course;
using mvc_web.Services;
using Refit;

namespace mvc_web.Controllers
{
  public class CourseController : Controller
  {
    private readonly ICourseService _iCourseService;

    public CourseController(ICourseService iCourseService)
    {
      _iCourseService = iCourseService;
    }

    public IActionResult Register()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCourseViewModelInput newCourseData)
    {
      try
      {
        var course = await _iCourseService.Register(newCourseData);
        ModelState.AddModelError("", $"Curso {course.Name} cadastrado com sucesso");
      }
      catch (ApiException ex)
      {
        ModelState.AddModelError("", ex.Message);
      }
      catch (Exception ex)
      {
        ModelState.AddModelError("", ex.Message);
      }

      return View();
    }

    public IActionResult List()
    {
      var courses = new List<ListCoursesViewModelOutput> {
        new ListCoursesViewModelOutput()
          {
            Name = "A",
            Description = "Descrição do curso A",
            Login = "Login aleatório 1"
          },
        new ListCoursesViewModelOutput()
          {
            Name = "B",
            Description = "Descrição do curso B",
            Login = "Login aleatório 1"
          },
        new ListCoursesViewModelOutput()
          {
            Name = "C",
            Description = "Descrição do curso C",
            Login = "Login aleatório 2"
          }
      };

      return View(courses);
    }
  }
}