using DotNet.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EF.Configuration
{
    /// <summary>
    /// 配置Menu映射
    /// </summary>
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Name).IsRequired().HasMaxLength(16).IsUnicode(); ;
            builder.Property(r => r.Icon).HasMaxLength(16).IsUnicode(false); ;
            builder.Property(r => r.ControllerNameCode).HasMaxLength(32).IsUnicode(false); ;
            builder.Property(r => r.ActionNameCode).HasMaxLength(32).IsUnicode(false); ;
        }
    }
}