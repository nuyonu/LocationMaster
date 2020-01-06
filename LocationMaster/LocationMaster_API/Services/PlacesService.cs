using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
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
                return new SavePlaceResponse($"An error occurred when saving the place: {e.Message}");
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
            return place == null ? new PlaceInfoResponse("Not found") : new PlaceInfoResponse(place);
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

            if (result.PageCount < page && result.RowCount != 0)
                return new PlacesResponse($"Page should be lowest than {result.PageCount}");

            if (result.RowCount == 0)
            {
                var noContent = PagedResult<Place>.NoContent<PlaceInfoResource>(result);
                return new PlacesResponse(noContent);
            }

            var viewPlaces = PagedResult<Place>.CopyPageInfo<PlaceInfoResource>(result);
            var listOfViewPlaces = result.Results.Select(place => new PlaceInfoResource(place)).ToList();
            viewPlaces.Results = listOfViewPlaces;
            return new PlacesResponse(viewPlaces);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingPlace = await _unitOfWork.Locations.FindByIdAsync(id);
            if (existingPlace == null)
                return false;
            try
            {
                _unitOfWork.Locations.Remove(existingPlace);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Response<List<PlaceInfoResource>> GetPlaceOfModerator(Guid id)
        {
            var result = _unitOfWork.Locations.GetPlacesOfModerator(id);
            var list = result.Select(place => new PlaceInfoResource(place)).ToList();
            return list.Count == 0
                ? new Response<List<PlaceInfoResource>>($"No places found for this user {id}")
                : new Response<List<PlaceInfoResource>>(list);
        }

        public Response<PlaceSave> SaveAsync(PlaceSave resource)
        {
            var user = _unitOfWork.Users.Find(e => e.UserId == resource.OwnerId).ToList();
            var category = _unitOfWork.Category.Find(e => e.Name == resource.Category).ToList();
            if (user.Count != 1)
                return new Response<PlaceSave>("User not found");
            Category newCategory;
            if (category.Count != 1)
            {
                newCategory = Category.Create(resource.Category);
                _unitOfWork.Category.Add(newCategory);
            }
            else
                newCategory = category.First();

            var place = Place.Create(user.First(), resource.Name, resource.Description, newCategory,
                Convert.ToSingle(resource.TicketPrice), resource.Address, resource.Lat, resource.Ltn);

            var used = 0;
            var guids = GeneratePaths(resource.PhotosContentStreams.Count);
            foreach (var stream in resource.PhotosContentStreams.Select(entry => new MemoryStream(entry.Value)))
            {
                FileService.SaveStreamAsFile(Path.Combine(Directory.GetCurrentDirectory(), PathFolder), stream,
                    guids[used] + ".png");
//                place.Photos.Add(Photo.Create(Directory.GetCurrentDirectory() + guids[used] + ".png"));
                var photo = Photo.Create(Path.Combine(PathFolder, guids[used] + ".png"));
                place.Photos.Add(photo);
                _unitOfWork.Photo.Add(photo);
                used++;
            }

            _unitOfWork.Locations.Add(place);

            _unitOfWork.Complete();
            return new Response<PlaceSave>(resource);
        }

        public void Update(PlaceSave value, Guid id)
        {
            var place = _unitOfWork.Locations.GetById(id);
            place.Update(value);
            var used = 0;
            var guids = GeneratePaths(value.PhotosContentStreams.Count);
            foreach (var stream in value.PhotosContentStreams.Select(entry => new MemoryStream(entry.Value)))
            {
                FileService.SaveStreamAsFile(Path.Combine(Directory.GetCurrentDirectory(), PathFolder), stream,
                    guids[used] + ".png");
                var photo = Photo.Create(Path.Combine(PathFolder, guids[used] + ".png"));
                place.Photos.Add(photo);
                _unitOfWork.Photo.Add(photo);
                used++;
            }

            _unitOfWork.Locations.Update(place);
            _unitOfWork.Complete();
        }

        public PlacesService(LocationMasterContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        private List<string> GeneratePaths(int size)
        {
            var guids = new List<string>();
            for (var index = 0; index < size; index++)
            {
                var temp = Guid.NewGuid().ToString();
                var resultGuid = _unitOfWork.Photo.Find(p => p.Path == temp).ToList();
                while (resultGuid.Count != 0)
                {
                    temp = Guid.NewGuid().ToString();
                    resultGuid = _unitOfWork.Photo.Find(p => p.Path == temp).ToList();
                }

                guids.Add(temp);
            }

            return guids;
        }

        private readonly UnitOfWork _unitOfWork;
        private static readonly string PathFolder = Path.Combine("StaticFiles", "Images", "PlacePhotos");

        private static List<string> _fields = new List<string>() {"owner", "category", "name", "price"};
    }
}