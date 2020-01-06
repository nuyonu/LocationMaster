using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Services;
using LocationMaster_API.Domain.Services.Communication;
using LocationMaster_API.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LocationMaster_API.Services
{
    public class ImageService : IImageService
    {
        private readonly UnitOfWork _unitOfWork;

        public ImageService(LocationMasterContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        public async Task<byte[]> GetFileByPath(string path)
        {
            string pathFile = Directory.GetCurrentDirectory() + path;
            if (!System.IO.File.Exists(pathFile))
                throw new FileNotFoundException("This file was not found.");
            byte[] file = await File.ReadAllBytesAsync(pathFile);

            return file;
        }

        public async Task<string> GetPathById(Guid id)
        {
            Photo photo = await _unitOfWork.Photo.FindByIdAsync(id);
            return photo.Path;
        }

        public Response<Dictionary<string, byte[]>> GetPathByPlaceId(Guid id)
        {
            var place = _unitOfWork.Locations.GetById(id);
            if (place == null)
                return new Response<Dictionary<string, byte[]>>("Place not found");
            var list=new Dictionary<string, byte[]>();
            foreach (var photo in place.Photos)
            {
                var data=FileService.GetBytesOfImage(Directory.GetCurrentDirectory(), photo.Path);
                list.Add(photo.PhotoId.ToString(),data);
            }
            return new Response<Dictionary<string, byte[]>>(list);
        }

        public async Task<ImageResponse> UpdateByIdAsync(Guid id, string image)
        {
            Photo photo = await _unitOfWork.Photo.FindByIdAsync(id);
            if (photo == null)
                return new ImageResponse("Image doesn't exist.");

            /*byte[] imageBytes = Encoding.ASCII.GetBytes(image);*/
            byte[] imageBytes = Convert.FromBase64String(image);
            string photoPath = photo.Path;
            string fullPath = Directory.GetCurrentDirectory() + photoPath;

            if (fullPath.Contains(id.ToString()))
            {
                using (var imageFile = new FileStream(fullPath, FileMode.Create))
                {
                    imageFile.Write(imageBytes, 0, imageBytes.Length);
                    imageFile.Flush();
                }
            }
            else
            {
                var folderPath = photoPath.Substring(0, photoPath.IndexOf("Default"));
                string workingDirectory = Directory.GetCurrentDirectory();
                string newImagePath = folderPath + id + ".png";
                string finalPath = workingDirectory + newImagePath;

                using (var imageFile = new FileStream(finalPath, FileMode.Create))
                {
                    imageFile.Write(imageBytes, 0, imageBytes.Length);
                    imageFile.Flush();
                }

                /*File.WriteAllBytes(finalPath, imageBytes);*/
                photo.SetNewPath(newImagePath);
            }

            _unitOfWork.Photo.Update(photo);
            await _unitOfWork.CompleteAsync();
            return new ImageResponse(photo);
        }
    }
}