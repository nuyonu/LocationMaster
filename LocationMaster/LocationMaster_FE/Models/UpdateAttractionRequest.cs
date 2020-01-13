using System;

namespace LocationMaster_FE.Models
{
    public class UpdateAttractionRequest
    {
        public Guid AttractionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public static UpdateAttractionRequest Create(AttractionResponse attractionResponse)
        {
            return new UpdateAttractionRequest()
            {
                AttractionId = attractionResponse.AttractionId,
                Name = attractionResponse.Name,
                Description = attractionResponse.Description,
                Photo = new byte[0]
            };
        }

        public UpdateAttractionRequest()
        {
            AttractionId = new Guid();
            Photo=new byte[0];
        }
    }
}