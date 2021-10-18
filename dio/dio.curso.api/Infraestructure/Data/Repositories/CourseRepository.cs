using System.Collections.Generic;
using System.Linq;
using api.Business.Entities;
using api.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace api.Infraestructure.Data.Repositories
{
  public class CourseRepository : ICourseRepository
  {
    private readonly CourseDBContext _context;

    public CourseRepository(CourseDBContext context)
    {
      _context = context;
    }

    public void Add(Course course)
    {
      _context.Course.Add(course);
    }

    public void Commit()
    {
      _context.SaveChanges();
    }

    public IList<Course> GetByUser(int userCode)
    {
      return _context.Course.Include(i => i.User).Where(w => w.UserCode == userCode).ToList();
    }
  }
}