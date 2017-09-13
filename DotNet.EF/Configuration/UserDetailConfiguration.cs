using DotNet.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EF.Configuration
{
    public class UserDetailConfiguration : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.HasKey(r => r.UserAccountId);
            builder.Property(r => r.NickName).IsUnicode(true).HasMaxLength(16);
            builder.Property(r => r.Address).IsUnicode(true).HasMaxLength(48);
            builder.Property(r => r.PhoneNumber).IsUnicode(false).HasMaxLength(13);
            builder.Property(r => r.Description).IsUnicode(true).HasMaxLength(200);
            builder.Property(r => r.PhotoPath).IsUnicode(false).HasMaxLength(48);
        }
    }
}