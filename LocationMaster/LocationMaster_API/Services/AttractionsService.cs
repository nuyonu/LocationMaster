using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Resources;

namespace LocationMaster_API.Services
{
    public class AttractionsService
    {
        public AttractionsService(LocationMasterContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public IEnumerable<AttractionsResource> GetAttractionsForPlace(Guid id, bool image)
        {
            var result = _unitOfWork.Locations.GetById(id);
            if (image)
            {
                return result.Attractions.Select(attraction => new AttractionsResource()
                {
                    AttractionId = attraction.AttractionId, Name = attraction.Name,
                    Description = attraction.Description,
                    Photo = FileService.GetBytesOfImage(Directory.GetCurrentDirectory(), attraction.Photo.Path)
                }).ToList();
            }
            else
            {
                return result.Attractions.Select(attraction => new AttractionsResource()
                {
                    AttractionId = attraction.AttractionId, Name = attraction.Name,
                    Description = attraction.Description,
                    Photo = new byte[0]
                }).ToList();
            }
        }

        public Response<AttractionsResource> SaveAttraction(Guid id, SaveAttractionResource resource)
        {
            var name = $"{GeneratePath()}.png";
            FileService.SaveStreamAsFile(Path.Combine(Directory.GetCurrentDirectory(), PathFolder),
                new MemoryStream(resource.Photo), name);
            var attraction = Attraction.Create(resource.Name, resource.Description,
                Photo.Create(Path.Combine(PathFolder, name)));
            var place = _unitOfWork.Locations.GetById(id);
            if (place == null)
                return new Response<AttractionsResource>("Place is not found");
            place.Attractions.Add(attraction);
            _unitOfWork.Locations.Update(place);
            _unitOfWork.Attraction.Add(attraction);
            _unitOfWork.Complete();
            return new Response<AttractionsResource>(AttractionsResource.CreateResource(attraction));
        }

        private string GeneratePath()
        {
            var temp = Guid.NewGuid().ToString();
            var resultGuid = _unitOfWork.Photo.Find(p => p.Path == temp).ToList();
            while (resultGuid.Count != 0)
            {
                temp = Guid.NewGuid().ToString();
                resultGuid = _unitOfWork.Photo.Find(p => p.Path == temp).ToList();
            }

            return temp;
        }

        private readonly IUnitOfWork _unitOfWork;
        private static readonly string PathFolder = Path.Combine("StaticFiles", "Images", "AttractionsPhotos");

        public bool Delete(Guid guid)
        {
            var result = _unitOfWork.Attraction.GetWithPhoto(guid);
            if (result == null)
                return false;
            File.Delete(Path.Combine(Directory.GetCurrentDirectory(), result.Photo.Path));
            _unitOfWork.Attraction.Remove(result);
            _unitOfWork.Complete();
            return true;
        }


        public Response<Attraction> Update(UpdateAttractionRequest request)
        {
            var result = _unitOfWork.Attraction.GetWithPhoto(request.AttractionId);
            if (result == null)
                return new Response<Attraction>("Attraction not found");
            result.Update(request);
            _unitOfWork.Attraction.Update(result);
            _unitOfWork.Complete();
            if (request.Photo.Length > 0)
                FileService.SaveStreamAsFile(Directory.GetCurrentDirectory(),
                    new MemoryStream(request.Photo), result.Photo.Path);
            return new Response<Attraction>(result);
        }
    }
}