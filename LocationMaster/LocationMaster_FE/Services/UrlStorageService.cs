using LocationMaster_FE.Helpers;

namespace LocationMaster_FE.Services
{
    public class UrlStorageService
    {
        public string BaseUrl { get; private set; }
        public string Port { get; private set; }
        public string Version { get; private set; }
        public string PlaceAutocomplete { get; private set; }
        public string GeoCodeUrl { get; private set; }
        public string KeyAutocomplet { get; private set; }
        public UrlStorageService()
        {
            BaseUrl = AppConfig.BaseUrl;
            Port = AppConfig.Port;
            Version = "v1.0";
            GeoCodeUrl = AppConfig.BaseUrl + AppConfig.Port + "/api/v1.0/ProxyCors/Geo";
            PlaceAutocomplete = AppConfig.BaseUrl + AppConfig.Port + "/api/v1.0/ProxyCors";
            KeyAutocomplet= "AIzaSyCi4urwHsvNARToGpCz32RSigv_vT8hbuo";
        }

        public string GetUrl()
        {
            return BaseUrl + Port + "/api/" + Version;
        }
    }
}