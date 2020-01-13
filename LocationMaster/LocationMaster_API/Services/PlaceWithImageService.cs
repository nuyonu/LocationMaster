using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.UnitOfWork;
using LocationMaster_API.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LocationMaster_API.Services
{
    public class PlaceWithImageService
    {
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

        public async Task<string> SavePlaceAsync(PlaceSave resource)
        {
            var used = 0;
            var user = await _unitOfWork.Users.FindByIdAsync(resource.OwnerId);
            if (user == null)
                return "Owner not found";
            var categories = _unitOfWork.Category.Find(e => e.Name.ToLower() == resource.Category).ToList();
            var newCategory = categories.Count == 0 ? Category.Create(resource.Category) : categories.First();
            var location = Place.Create(user, resource.Name, resource.Description, newCategory,
                Convert.ToSingle(resource.TicketPrice));
            var guids = GeneratePaths(resource.PhotosContentStreams.Count);
            foreach (var stream in resource.PhotosContentStreams.Select(entry => new MemoryStream(entry.Value)))
            {
                FileService.SaveStreamAsFile(Directory.GetCurrentDirectory(), stream, guids[used] + ".png");
                location.Photos.Add(Photo.Create(Directory.GetCurrentDirectory() + guids[used] + ".png"));
                used++;
            }

            _unitOfWork.Locations.AddAsync(location);
            return "Success";
        }

        public PlaceWithImageService(LocationMasterContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        private readonly UnitOfWork _unitOfWork;
    }
}