using CourseDesigner.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseDesigner.DataBase.Configurations_
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                 .HasMany(l => l.Problems)
                 .WithMany(p => p.Lessons)
                 .UsingEntity<Dictionary<string, object>>(
                     "LessonProblems",
                     j => j
                         .HasOne<Problem>()
                         .WithMany()
                         .HasForeignKey("ProblemId"),
                     j => j
                         .HasOne<Lesson>()
                         .WithMany()
                         .HasForeignKey("LessonId")
                );
        }
    }
}
