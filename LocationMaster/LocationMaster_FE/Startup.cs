using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using LocationMaster_FE.Auth;
using LocationMaster_FE.ContainerState;
using LocationMaster_FE.Helpers;
using LocationMaster_FE.Services;
using LocationMaster_FE.Services.IServices;
using MatBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace LocationMaster_FE
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore();
            services.AddScoped<JWTAuthenticationProvider>();
            services.AddScoped<AuthenticationStateProvider, JWTAuthenticationProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationProvider>());
            services.AddScoped<ILoginService, JWTAuthenticationProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationProvider>());
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ProfileImageState, ProfileImageState>();
            services.AddLogging();
            services.ConfigureDependencyInjection();
            services.ConfigureComponents();
            services.ConfigureStorage();

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new System.Collections.Generic.Dictionary<string, string> { { "key", "value" } })
                .Build();
            services.AddSingleton(config);
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();
            app.AddComponent<App>("app");
        }
    }
}