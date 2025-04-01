using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.Business.Services.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace CourseDesigner.Business.Extension
{
    public static class Extensions
    {
        public static IServiceCollection AddBussiness(this IServiceCollection services)
        {
            services.AddScoped<IProblemService, ProblemService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ICourseService, CourseService>();

            return services;
        }
    }
}
