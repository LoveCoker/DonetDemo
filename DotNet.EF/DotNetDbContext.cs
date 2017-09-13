using DotNet.EF.Configuration;
using DotNet.Infrastructure.Interface;
using DotNet.Model;
using DotNet.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace DotNet.EF
{
    public class DotNetDbContext: DbContext, IDbContext
    {
        public DotNetDbContext(DbContextOptions<DotNetDbContext> options) : base(options)
        {
            //web层中 startup中注入
        }

        //Add-Migration init
        //Update-Database init
        public DbSet<UserAccount> UserAccount { set; get; }
        //public DbSet<UserDetail> UserDetail { set; get; }
        public DbSet<Button> Button { set; get; }
        public DbSet<Department> Department { set; get; }
        public DbSet<Menu> Menu { set; get; }
        public DbSet<Role> Role { set; get; }
        //public DbSet<RefMenuButton> RefMenuButton { set; get; }
        public DbSet<RefRoleMenuButton> RefRoleMenuButton { set; get; }
        public DbSet<RefUserRole> RefUserRole { set; get; }
        public DbSet<RefUserDepartment> RefUserDepartment { set; get; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //领域模型不参杂任何的技术实现。
            //数据库的映射配置，属于技术实现，应该放在基础层中。
            modelBuilder.ApplyConfiguration(new ButtonConfiguration());
            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new UserDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }
       
    }
}