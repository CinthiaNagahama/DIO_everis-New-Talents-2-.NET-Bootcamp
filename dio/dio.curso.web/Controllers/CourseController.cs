using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dio.curso.web.Models.Course;
using dio.curso.web.Services;
using Refit;

namespace dio.curso.web.Controllers
{
  [Microsoft.AspNetCore.Authorization.Authorize]
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

    public async Task<IActionResult> ListCourses()
    {
      var courses = await _iCourseService.Get();

      return View(courses);
    }
  }
}