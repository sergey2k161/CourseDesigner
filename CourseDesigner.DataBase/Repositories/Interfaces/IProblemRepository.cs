using CourseDesigner.DataBase.Models;

namespace CourseDesigner.DataBase.Repositories.Interfaces
{
    public interface IProblemRepository
    {
        Task CreateProblem(Problem problem);

        Task<List<Problem>> GetProblems();

        Task DeleteProblem(Guid id);
    }
}
