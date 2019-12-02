using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Reponses;
using LocationMaster_API.Services.IServices;

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
                return new SavePlaceResponse(place);
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
                return new SavePlaceResponse(place);
            }
            catch (Exception e)
            {
                return new SavePlaceResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

     

        public PlacesResponse GetPage(int page, int sizePage, bool @descending, string orderBy, string search)
        {
//            Console.Write();
            if (orderBy.ToLower() == "owner")
                return new PlacesResponse(_unitOfWork.Locations.GetPage(page, sizePage, descending, search,
                    s => s.Owner));
            if (orderBy.ToLower() == "category")
                return new PlacesResponse(_unitOfWork.Locations.GetPage(page, sizePage, descending, search,
                    s => s.Category));
//todo fix for ticket price
            //            if (orderBy.ToLower() == "price")
//                return new PlacesResponse(_unitOfWork.Locations.GetPage(page, sizePage, descending,search,s=>s.T));
            return new PlacesResponse($"Invalid order filter: {orderBy}");
        }

        public PlacesService(LocationMasterContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        private readonly UnitOfWork _unitOfWork;
    }
}