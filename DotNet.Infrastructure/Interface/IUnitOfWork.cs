namespace DotNet.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 注册添加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void RegisterNew<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 注册修改
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void RegisterModify<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 注册删除
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 清空注册状态
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void RegisterClean<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        bool Commit();
        /// <summary>
        /// 回滚
        /// </summary>
        void Rollback();
    }
}