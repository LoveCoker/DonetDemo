using DotNet.Model;
using DotNet.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EF.Configuration
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.LoginAccount).IsRequired().HasMaxLength(24).IsUnicode(false);
            builder.Property(r => r.Email).IsRequired().HasMaxLength(32).IsUnicode(false);
            builder.Property(r => r.LoginPwd).IsRequired().HasMaxLength(32).IsUnicode(false);

            builder.HasOne(r=>r.UserDetail).WithOne().HasForeignKey<UserDetail>(r=>r.UserAccountId).HasPrincipalKey<UserAccount>(r=>r.Id);
        }
    }
}