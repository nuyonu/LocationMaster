

using LocationMaster_API.Models.Repository;
using LocationMaster_API.Models.Repository.IRepository;

namespace LocationMaster_API.Models.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ILocationRepository Locations { get; set; }
        public IUserRepository Users { get; set; }
        public IAttractionRepository Attraction { get; set; }
        public IBuyedTicketRepository Ticket { get; set; }
        public ICategoryRepository Category { get; set; }
        public IPhotoRepository Photo { get; set; }
        public IReviewRepository Review { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public UnitOfWork(LocationMasterContext context)
        {
            _context = context;
            Locations = new LocationsRepository(_context);
            Users=new UserRepository(_context);
            Attraction=new AttractionRepository(_context);
            Ticket=new BuyedTicketRepository(_context);
            Category=new CategoryRepository(_context);
            Photo=new PhotoRepository(_context);
            Review=new ReviewRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private readonly LocationMasterContext _context;
    }
}