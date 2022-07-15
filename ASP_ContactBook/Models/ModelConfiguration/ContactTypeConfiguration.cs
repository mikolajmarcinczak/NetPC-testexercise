using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_ContactBook.Models.ModelConfiguration
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.HasKey(x => x.TypeName);
            //One-to-many child object
            builder.HasMany<UserInfo>(ct => ct.Users)
                   .WithOne(ui => ui.ContactType)
                   .HasForeignKey(ui => ui.TypeName);
            //One-to-one relationship
            builder.HasOne<ContactTypeRole>(ct => ct.TypeRole)
                   .WithOne(ctr => ctr.ContactType)
                   .HasForeignKey<ContactTypeRole>(ctr => ctr.TypeName);
        }
    }
}
