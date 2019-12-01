using System;
using System.Threading.Tasks;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ILocationRepository Locations { get; set; }
        IUserRepository Users { get; set; }
        IAttractionRepository Attraction { get; set; }
        IBuyedTicketRepository Ticket { get; set; }
        ICategoryRepository Category { get; set; }
        IPhotoRepository Photo { get; set; }
        IReviewRepository Review { get; set; }

        int Complete();

        Task CompleteAsync();
    }
}