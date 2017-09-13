using DotNet.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNet.EF.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.DepartmentName).IsRequired().HasMaxLength(24).IsUnicode(true);
        }
    }
}