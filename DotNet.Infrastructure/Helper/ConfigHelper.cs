using System;
using DotNet.Infrastructure.Enum;
using DotNet.Infrastructure.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DotNet.Infrastructure.Helper
{
    public class ConfigHelper
    {
        readonly IConfiguration _configuration;
        public SiteConfig Config;
        public ConfigHelper(IConfiguration configuration, IOptions<SiteConfig> option)
        {
            _configuration = configuration;
            Config = option.Value;
        }
        //public string DefaultPath => _configuration["DefaultPath"];

        /// <summary>
        /// 采用的缓存方式
        /// </summary>
        public CacheTypeEnum CacheType => System.Enum.TryParse(_configuration["CacheType"], out CacheTypeEnum temp) ? temp : CacheTypeEnum.HttpRuntime;
        public CacheTypeEnum CacheType2 => System.Enum.TryParse(Config.CacheType, out CacheTypeEnum temp) ? temp : CacheTypeEnum.HttpRuntime;
    }
}