using DotNet.EF;
using DotNet.Infrastructure;
using DotNet.Infrastructure.Helper.Cache;
using DotNet.Infrastructure.Interface;
using DotNet.IService;
using DotNet.Model.IRepository;
using DotNet.Repository;
using DotNet.Service;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet.Web
{
    public class DIConfig
    {
        private static DIConfig _config;
        private static object o=new object();
        private DIConfig()
        {
        }

        public static DIConfig Current()
        {
            lock (o)
            {
                if (_config == null)
                {
                    _config = new DIConfig();
                }
            }
            return _config;
        }

        public void ConfigDI(IServiceCollection services)
        {
            services.AddSingleton<ICacheWriter, HttpRuntimeCachedWriter>();
            services.AddScoped<IUserAccountService, UserAccountService>();
            services.AddScoped<IUserAccountRepository, UserAccountRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContext, DotNetDbContext>();
        }
    }
}