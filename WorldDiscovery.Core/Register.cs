using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core
{
    public class Register
    {
        public static void All(IServiceCollection services)
        {
            Features.Identity.Register.Static(services);
            services.AddSingleton<Config>();
        }
    }
}
