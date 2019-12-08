using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Reponses;

namespace LocationMaster_API.Domain.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> ListAsync();
        Task<SavePlaceResponse> SaveAsync(Place place);
        Task<SavePlaceResponse> UpdateAsync(Guid id, Place user);
        PlacesResponse GetPage(int page, int sizePage, bool descending, string orderBy, string search);
        PlaceInfoResponse GetInfo(Guid id);
        Task<PlaceInfoResponse> DeleteAsync(Guid id);
    }
}