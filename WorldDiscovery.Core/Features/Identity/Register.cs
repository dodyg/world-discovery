using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorldDiscovery.Core.Features.Identity
{
    public static class Register
    {
        public static void Static(IServiceCollection services)
        {
            services.AddSingleton<IdentityManagement>();
        }
    }
}
