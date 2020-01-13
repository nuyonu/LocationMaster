using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.Repositories.Repositories;

namespace LocationMaster_API.Domain.Repositories
{
    public class BuyedTicketRepository : Repository<Attraction>, IBuyedTicketRepository
    {
        public BuyedTicketRepository(LocationMasterContext context) : base(context)
        {
            _context = context;
        }

        private readonly LocationMasterContext _context;
    }
}