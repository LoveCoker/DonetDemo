using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DotNet.Infrastructure.Interface
{
    /// <summary>
    /// IDbContext 的作用，就是提供对象列表的一切操作接口
    /// </summary>
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}