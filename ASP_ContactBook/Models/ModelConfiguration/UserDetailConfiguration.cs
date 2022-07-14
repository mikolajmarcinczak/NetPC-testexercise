using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_ContactBook.Models.ModelConfiguration
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasOne<ApplicationUser>(ud => ud.User)
                   .WithOne(u => u.UserDetail)
                   .HasForeignKey<UserDetail>(ud => ud.UserId);
        }
    }
}
