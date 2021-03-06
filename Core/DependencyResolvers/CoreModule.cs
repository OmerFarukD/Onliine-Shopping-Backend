using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CCS.Caching;
using Core.CCS.Caching.Microsoft;
using Core.Ioc;
using Core.Utilities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection provider)
        {
            provider.AddMemoryCache();
            provider.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            provider.AddSingleton<ICacheManager, MemoryCacheManager>();
            provider.AddSingleton<IFileHelper, FileHelperManager>();
            provider.AddSingleton<Stopwatch>();
        }
    }
}
