using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocationMaster_FE.Services.IServices
{
    public interface IGeolocationService
    {
        Task<string> GetLocation(Dictionary<string, double> response);
        Task<List<string>> GetPredictions(string input);
        Task<List<double>> GetCoordonate(string input);
    }
}