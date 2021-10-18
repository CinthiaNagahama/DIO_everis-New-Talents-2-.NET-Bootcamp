using api.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace api.Configuration
{
  public class DbFactoryDbContext : IDesignTimeDbContextFactory<CourseDBContext>
  {
    public IConfiguration Configuration { get; }
    public CourseDBContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<CourseDBContext>();
      optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
      CourseDBContext context = new CourseDBContext(optionsBuilder.Options);

      return context;
    }
  }
}