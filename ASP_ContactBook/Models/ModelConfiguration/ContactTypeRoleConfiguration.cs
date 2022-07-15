using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASP_ContactBook.Models.ModelConfiguration
{
    public class ContactTypeRoleConfiguration : IEntityTypeConfiguration<ContactTypeRole>
    {
        public void Configure(EntityTypeBuilder<ContactTypeRole> builder)
        {
            builder.HasKey(x => x.Role);
            builder.Property(x => x.TypeName).IsRequired();
            //One-to-one relationship
            builder.HasOne<ContactType>(ctr => ctr.ContactType)
                   .WithOne(ct => ct.TypeRole)
                   .HasForeignKey<ContactTypeRole>(ctr => ctr.TypeName);
        }
    }
}
