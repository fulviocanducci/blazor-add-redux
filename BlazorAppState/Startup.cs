using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;
using BlazorState;
using BlazorAppState.States;

namespace BlazorAppState
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazorState(options =>
               {
                   options.Assemblies = new Assembly[]
                     {
                        typeof(Startup).GetTypeInfo().Assembly,
                     };
                   options.UseReduxDevToolsBehavior = true;
                 }
             );
            services.AddScoped<CounterState>();

        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }


    }
}
