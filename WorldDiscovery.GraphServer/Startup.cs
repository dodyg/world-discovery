using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorldDiscovery.GraphServer.Components;
using Blazorise;
using Blazorise.Bulma;
using Blazorise.Icons.FontAwesome;

namespace WorldDiscovery.GraphServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddServerSideBlazor();

            WorldDiscovery.Core.Register.All(services);

            services.AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true; // optional
                })
                .AddBulmaProviders()
                .AddFontAwesomeIcons();

            services.AddSingleton<EventAggregator.Blazor.IEventAggregator, EventAggregator.Blazor.EventAggregator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.ApplicationServices
              .UseBulmaProviders()
              .UseFontAwesomeIcons();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapFallbackToPage("/Index");
                endpoints.MapBlazorHub<App>("app");
            });
        }
    }
}
