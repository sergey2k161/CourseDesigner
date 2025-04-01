using CourseDesigner.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseDesigner.DataBase.Configurations_
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .HasOne(c => c.Author)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.AuthorId);

            builder
                .HasMany(c => c.Lessons)
                .WithOne(l => l.Course)
                .HasForeignKey(l => l.CourseId);

            builder
                .HasMany(c => c.Subscribers)
                .WithMany(u => u.Courses)
                .UsingEntity<CourseSubscription>(
                    j => j
                        .HasOne(cs => cs.User)
                        .WithMany()
                        .HasForeignKey(cs => cs.UserId),
                    j => j
                        .HasOne(cs => cs.Course)
                        .WithMany()
                        .HasForeignKey(cs => cs.CourseId)
                );


        }
    }
}
