using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Reponses;

namespace LocationMaster_API.Services.IServices
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> ListAsync();
        Task<SavePlaceResponse> SaveAsync(Place user);
        Task<SavePlaceResponse> UpdateAsync(Guid id, Place user);
        PlacesResponse GetPage(int page, int sizePage, bool descending, string orderBy,string search);
    }
}