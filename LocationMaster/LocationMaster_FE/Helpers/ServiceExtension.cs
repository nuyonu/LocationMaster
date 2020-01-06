using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using LocationMaster_FE.ContainerState;
using LocationMaster_FE.Services;
using LocationMaster_FE.Services.IServices;
using MatBlazor;
using Microsoft.Extensions.DependencyInjection;

namespace LocationMaster_FE.Helpers
{
    public static class ServiceExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<PlaceService, PlaceService>();
            services.AddScoped<IGeolocationService, GeolocationService>();
            services.AddScoped<IAttractionsService, AttractionsService>();
            services.AddSingleton<UserService, UserService>();
            services.AddSingleton<UrlStorageService, UrlStorageService>();
        }

        public static void ConfigureComponents(this IServiceCollection services)
        {
            services.AddBlazorise(options => options.ChangeTextOnKeyPress = true)
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
            services.AddMatToaster(config =>
            {
                config.Position = MatToastPosition.BottomRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = true;
                config.ShowCloseButton = true;
                config.MaximumOpacity = 100;
                config.VisibleStateDuration = 3000;
                config.ShowProgressBar = true;
            });
        }

        public static void ConfigureStorage(this IServiceCollection services)
        {
            services.AddSingleton<SearchState, SearchState>();
            services.AddSingleton<PagesPlacesStorage, PagesPlacesStorage>();
            services.AddSingleton<SearchStorage, SearchStorage>();
            services.AddSingleton<Storage, Storage>();
        }
    }
}