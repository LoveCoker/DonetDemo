using DotNet.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EF.Configuration
{
    public class ButtonConfiguration : IEntityTypeConfiguration<Button>
    {
        public void Configure(EntityTypeBuilder<Button> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).HasMaxLength(8).IsUnicode();
            builder.Property(r => r.Icon).HasMaxLength(16).IsUnicode(false);
            builder.Property(r => r.Description).HasMaxLength(100).IsUnicode();
            builder.Property(r => r.HttpMethod).HasMaxLength(5).IsUnicode(false).IsRequired();
            builder.Property(r => r.ActionNameCode).HasMaxLength(24).IsUnicode(false).IsRequired();

        }
    }
}