using System;
using System.Linq;
using System.Threading.Tasks;
using DotNet.EF;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Web
{
    public class DataBaseInit
    {
        public static async Task InitDB(IServiceProvider service)
        {
            var db = service.GetService<DotNetDbContext>();

            if (db.Database != null && db.Database.EnsureCreated())
            {
                if (!db.Menu.Any())
                {
                    //todo 初始化表
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}