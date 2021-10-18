using api.Business.Entities;

namespace api.Business.Repositories
{
  public interface IUserRepository
  {
    void Add(User user);

    void Commit();

    User GetUser(string login);
  }
}