using api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Infraestructure.Data.Mappings
{
  public class CourseMapping : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.ToTable("TB_COURSE");
      builder.HasKey(p => p.Code);
      builder.Property(p => p.Code).ValueGeneratedOnAdd();
      builder.Property(p => p.Name);
      builder.Property(p => p.Description);
      builder.HasOne(p => p.User).WithMany().HasForeignKey(fk => fk.UserCode);
    }
  }
}