using CourseDesigner.DataBase.Models;
using CourseDesigner.DataBase.Models.DTOs;

namespace CourseDesigner.DataBase.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<ResultDto> RegisterUser(User user);
        Task<ResultDto> RegisterAuthor(Author author);
    }
}