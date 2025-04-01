using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseDesigner.DataBase.Repositories.DataAccessRepositories
{
    internal class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddLessonToCourse(Guid lessonId, Guid courseId)
        {
            var course = await _context.Courses
                .Include(l => l.Lessons)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            var lesson = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == lessonId);

            course.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCourse(Course course)
        {
            await _context.AddAsync(course);
            await _context.SaveChangesAsync();
        }
    }
}
