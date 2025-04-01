using CourseDesigner.DataBase.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDesigner.Business.Services.Interfaces
{
    public interface ILessonService
    {
        Task CreateLesson(LessonDto model);
        Task AddProblemToLesson(Guid problemId, Guid LessonId);
    }
}
