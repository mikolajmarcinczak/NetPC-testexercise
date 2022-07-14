using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_ContactBook.Models.ModelConfiguration
{
    public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.ContactType).IsRequired();
            builder.HasOne<ApplicationUser>(ui => ui.User)
                   .WithOne(u => u.UserInfo)
                   .HasForeignKey<UserInfo>(ui => ui.UserId);
            builder.HasOne<ContactType>(ui => ui.ContactType)
                   .WithMany(ct => ct.Users)
                   .HasForeignKey(ui => ui.TypeName);
        }
    }
}
