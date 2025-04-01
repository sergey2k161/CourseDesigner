using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseDesigner.DataBase.Repositories.DataAccessRepositories
{
    internal class ProblemRepository : IProblemRepository
    {
        private readonly AppDbContext _context;

        public ProblemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProblem(Problem problem)
        {
            await _context.Problems.AddAsync(problem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProblem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Problem>> GetProblems()
        {
            return await _context.Problems.ToListAsync();
        }
    }

}