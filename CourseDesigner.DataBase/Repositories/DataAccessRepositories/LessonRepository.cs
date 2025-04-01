using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CourseDesigner.DataBase.Repositories.DataAccessRepositories
{
    internal class LessonRepository : ILessonRepository
    {
        private readonly AppDbContext _context;

        public LessonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddProblemToLesson(Guid problemId, Guid lessonId)
        {
            var lesson = await _context.Lessons
                .Include(l => l.Problems)
                .FirstOrDefaultAsync(l => l.Id == lessonId);

            var problem = await _context.Problems
                .FirstOrDefaultAsync(c => c.Id == problemId);

            lesson.Problems.Add(problem);
            await _context.SaveChangesAsync();

        }

        public async Task CreateLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
