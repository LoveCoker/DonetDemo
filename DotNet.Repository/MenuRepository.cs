using System.Linq;
using DotNet.Infrastructure.Interface;
using DotNet.Model.Entity;

namespace DotNet.Repository
{
    public class MenuRepository
    {
        private readonly IQueryable<Menu> _menus;

        public MenuRepository(IDbContext dbContext)
        {
            _menus = dbContext.Set<Menu>();
        }
        public Menu Get(int id)
        {
            return _menus.FirstOrDefault(x => x.Id == id);
        }
    }
}