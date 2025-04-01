using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDesigner.DataBase.Models.DTOs
{
    public class ProblemDto
    {
        public required string Name { get; set; }

        public required double Complexity { get; set; }

        public string? Description { get; set; }

        // Тип вопроса, возможные значения: MultipleChoice, TrueFalse, Text
        public string? ResponseType { get; set; }

        // Варианты ответа
        public string? AnswerOptions { get; set; }

        // Верный ответ
        public string? CurrentAnswer { get; set; }
    }
}
