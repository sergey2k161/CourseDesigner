using System.ComponentModel.DataAnnotations.Schema;

namespace CourseDesigner.DataBase.Models
{
    public class  Problem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required double Complexity { get; set; }

        public string? Description { get; set; }

        // Тип вопроса, возможные значения: MultipleChoice, TrueFalse, Text
        public string? ResponseType { get; set; }   

        // Варианты ответа
        public string? AnswerOptions { get; set; }

        // Верный ответ
        public string? CurrentAnswer { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}

