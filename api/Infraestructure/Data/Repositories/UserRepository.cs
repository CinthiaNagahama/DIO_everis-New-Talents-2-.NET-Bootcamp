using System.Linq;
using api.Business.Entities;
using api.Business.Repositories;

namespace api.Infraestructure.Data.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly CourseDBContext _context;

    public UserRepository(CourseDBContext context)
    {
      _context = context;
    }

    public void Add(User user)
    {
      _context.User.Add(user);
    }

    public void Commit()
    {
      _context.SaveChanges();
    }

    public User GetUser(string login)
    {
      return _context.User.FirstOrDefault(u => u.Login == login);
    }
  }
}