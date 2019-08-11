using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core
{
    public static class Register
    {
        public static void All(IServiceCollection services)
        {
            Features.Identity.Register.Static(services);
            services.AddSingleton<Config>();
            services.AddSingleton<Features.LayoutDataService>();
            services.AddSingleton<Features.GlobalMessage>();
        }
    }
}
