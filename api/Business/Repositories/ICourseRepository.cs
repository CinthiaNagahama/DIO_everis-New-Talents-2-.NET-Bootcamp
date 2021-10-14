using System.Collections.Generic;
using api.Business.Entities;

namespace api.Business.Repositories
{
  public interface ICourseRepository
  {
    void Add(Course course);

    void Commit();

    IList<Course> GetByUser(int userCode);
  }
}