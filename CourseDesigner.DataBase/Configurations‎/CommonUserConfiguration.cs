using CourseDesigner.DataBase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseDesigner.DataBase.Configurations_
{
    public class CommonUserConfiguration : IEntityTypeConfiguration<CommonUser>
    {
        public void Configure(EntityTypeBuilder<CommonUser> builder) 
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.User)
                .WithOne(u => u.CommonUser)
                .HasForeignKey<User>(u => u.CommonUserId);

            builder
                .HasOne(c => c.Author)
                .WithOne(a => a.CommonUser)
                .HasForeignKey<Author>(u => u.CommonUserId);
        }
    }
}
