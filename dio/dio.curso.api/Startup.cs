using api.Business.Repositories;
using api.Configurations;
using api.Infraestructure.Data;
using api.Infraestructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace dio.curso.api {
  public class Startup {
    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {

      services.AddControllers()
        .ConfigureApiBehaviorOptions(options => {
          options.SuppressModelStateInvalidFilter = true;
        }
      );

      services.AddSwaggerGen(c => 
      {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
        {
          Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            Array.Empty<string>()
          }
        });

        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });

      var secret = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtConfigurations:Secret").Value);

      services.AddAuthentication(x => 
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x => 
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters 
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(secret),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));

      services.AddDbContext<CourseDBContext>(options => {
        options.UseSqlServer(
          Configuration.GetConnectionString("DefaultConnection"),
          x => x.MigrationsAssembly(typeof(CourseDBContext).Assembly.FullName).EnableRetryOnFailure());
      });
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<ICourseRepository, CourseRepository>();
      services.AddScoped<IAuthenticationService, JwtService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) 
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");
          c.RoutePrefix = string.Empty;
        });
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => 
      {
        endpoints.MapControllers();
      });
    }
  }
}