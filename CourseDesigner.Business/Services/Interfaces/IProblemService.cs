using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Models.DTOs;

namespace CourseDesigner.Business.Services.Interfaces
{
    public interface IProblemService
    {
        Task CreateProblem(ProblemDto model);

        Task<List<Problem>> GetProblems();

    }
}
