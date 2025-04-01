using CourseDesigner.DataBase.Repositories.DataAccessRepositories;
using CourseDesigner.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CourseDesigner.DataBase.Extension
{
    public static class Extensions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services)
        {

            services.AddScoped<IProblemRepository, ProblemRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();


            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseNpgsql("Host=localhost;Database=Courses;Username=sergey;Password=1618");
            });

            return services;
        }
    }
}
