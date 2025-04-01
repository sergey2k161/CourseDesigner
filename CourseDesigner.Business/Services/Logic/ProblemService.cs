using CourseDesigner.Business.Services.Interfaces;
using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Models.DTOs;
using CourseDesigner.DataBase.Repositories.Interfaces;

namespace CourseDesigner.Business.Services.Logic
{
    internal class ProblemService : IProblemService
    {
        private readonly IProblemRepository _problemRepository;

        public ProblemService(IProblemRepository problemRepository)
        {
            _problemRepository = problemRepository;
        }

        public async Task CreateProblem(ProblemDto model)
        {
            var problem = new Problem
            {
                Name = model.Name,
                Complexity = model.Complexity,
                Description = model.Description,
                ResponseType = model.ResponseType,
                AnswerOptions = model.AnswerOptions,
                CurrentAnswer = model.CurrentAnswer
            };

            await _problemRepository.CreateProblem(problem);
        }

        public async Task<List<Problem>> GetProblems()
        {
            return await _problemRepository.GetProblems();
        }
    }
}
