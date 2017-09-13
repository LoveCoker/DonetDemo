using DotNet.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EF.Configuration
{
    public class RoleConfiguration: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.RoleName).IsRequired().IsUnicode().HasMaxLength(16);
            builder.Property(r => r.Description).IsUnicode().HasMaxLength(100);
            builder.Property(r => r.DepartmentId).IsRequired();
        }
    }
}