using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocationMaster_FE.Models;
using LocationMaster_FE.Models.Responses;

namespace LocationMaster_FE.Services.IServices
{
    public interface IAttractionsService
    {
        Task delete(Guid id);
        bool Save(Guid id, SaveAttractionResource resource);
        Task<Response<List<AttractionResponse>>> Get(Guid id);
        Task<Response<List<AttractionResponse>>> GetImages(Guid id);
        Task Put(UpdateAttractionRequest request);
    }
}