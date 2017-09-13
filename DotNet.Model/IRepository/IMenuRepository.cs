using DotNet.Model.Entity;

namespace DotNet.Model.IRepository
{
    public interface IMenuRepository
    {
        Menu Get(int id);
    }
}