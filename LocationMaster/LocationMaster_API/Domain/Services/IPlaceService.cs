using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Reponses;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Domain.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> ListAsync();
        Task<SavePlaceResponse> SaveAsync(Place place);
        Task<SavePlaceResponse> UpdateAsync(Guid id, Place user);
        PlacesResponse GetPage(int page, int sizePage, bool descending, string orderBy, string search);
        PlaceInfoResponse GetInfo(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Response<List<PlaceInfoResource>> GetPlaceOfModerator(Guid id);
        Response<List<PlaceInfoResource>> GetPlacesByPrice(int count, bool ascending);
        Response<PlaceSave> SaveAsync(PlaceSave resource);
        void Update(PlaceSave value, Guid id);
    }
}