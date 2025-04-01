using CourseDesigner.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseDesigner.DataBase.Configurations_
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(u => u.CommonUser)
                .WithOne()
                .HasForeignKey<User>(u => u.CommonUserId);
        }
    }
}
