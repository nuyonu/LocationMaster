using System;
using System.ComponentModel.DataAnnotations;

namespace LocationMaster_API.Resources
{
    public class UpdateAttractionRequest
    {
        [Required]
        public Guid AttractionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(40)]
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public UpdateAttractionRequest()
        {
        }
    }
}