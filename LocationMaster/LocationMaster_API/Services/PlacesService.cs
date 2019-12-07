using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Pages;
using LocationMaster_API.Reponses;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Services 
{
    public class PlacesService : IPlaceService
    {
        public async Task<IEnumerable<Place>> ListAsync()
        {
            return await _unitOfWork.Locations.ListAsync();
        }

        public async Task<SavePlaceResponse> SaveAsync(Place place)
        {
            try
            {
                await _unitOfWork.Locations.AddAsync(place);
                await _unitOfWork.CompleteAsync();
                return new SavePlaceResponse(new PlaceInfoResource(place));
            }
            catch (Exception e)
            {
                return new SavePlaceResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public async Task<SavePlaceResponse> UpdateAsync(Guid id, Place place)
        {
            var existingPlace = await _unitOfWork.Locations.FindByIdAsync(id);
            if (existingPlace == null)
                return new SavePlaceResponse("Place not found");
            try
            {
                _unitOfWork.Locations.Update(place);
                await _unitOfWork.CompleteAsync();
                return new SavePlaceResponse(new PlaceInfoResource(place));
            }
            catch (Exception e)
            {
                return new SavePlaceResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public PlaceInfoResponse GetInfo(Guid id)
        {
            var place = _unitOfWork.Locations.GetById(id);
            return place == null ? new PlaceInfoResponse(404) : new PlaceInfoResponse(place);
        }


        public PlacesResponse GetPage(int page, int sizePage, bool @descending, string orderBy, string search)
        {
            if (!_fields.Contains(orderBy))
                return new PlacesResponse($"Invalid order filter: {orderBy}");
            if (sizePage < 5 && sizePage > 100)
                return new PlacesResponse($"Page size should be greater than 5 and lower than 100");
            if (page < 1)
                return new PlacesResponse($"Page should be greater than 1 : {page}");
            var result = _unitOfWork.Locations.GetPage(page, sizePage, descending, search, orderBy);
            if (result.PageCount < page)
                return new PlacesResponse($"Page should be lowest than {result.PageCount}");
            var viewPlaces = PagedResult<Place>.CopyPageInfo<PlaceInfoResource>(result);
            var listOfViewPlaces = result.Results.Select(place => new PlaceInfoResource(place)).ToList();

            viewPlaces.Results = listOfViewPlaces;
            return new PlacesResponse(viewPlaces);
        }

        public async Task<PlaceInfoResponse> DeleteAsync(Guid id)
        {
            var existingPlace = await _unitOfWork.Locations.FindByIdAsync(id);
            if (existingPlace == null)
                return new PlaceInfoResponse(400);
            try
            {
                _unitOfWork.Locations.Remove(existingPlace);
                await _unitOfWork.CompleteAsync();
                return new PlaceInfoResponse(existingPlace);
            }
            catch (Exception e)
            {
                return new PlaceInfoResponse($"An error eccurred when deleting the place :{e.Message}");
            }
        }

        public PlacesService(LocationMasterContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }


        private readonly UnitOfWork _unitOfWork;
        private static List<string> _fields = new List<string>() {"owner", "category", "name", "price"};
    }
}