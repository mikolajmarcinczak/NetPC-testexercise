using ASP_ContactBook.Models;
using ASP_ContactBook.Models.ModelConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_ContactBook.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<ApplicationUser> ApplicationUser {get; set;}
        public DbSet<UserInfo> UserInfo {get; set;}
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<ContactTypeRole> ContactTypeRole { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new UserInfoConfiguration());
            builder.ApplyConfiguration(new UserDetailConfiguration());
            builder.ApplyConfiguration(new ContactTypeConfiguration());
            builder.ApplyConfiguration(new ContactTypeRoleConfiguration());
            base.OnModelCreating(builder);
        }
    }
}