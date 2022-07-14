using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_ContactBook.Models.ModelConfiguration
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PasswordHash).IsRequired();
            builder.HasOne<UserInfo>(x => x.UserInfo)
                   .WithOne(ui => ui.User)
                   .HasForeignKey<UserInfo>(ui => ui.UserId);
            builder.HasOne<UserDetail>(x => x.UserDetail)
                   .WithOne(ud => ud.User)
                   .HasForeignKey<UserDetail>(ud => ud.UserId);
        }
    }
}
