using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocationMaster_API.Domain;
using LocationMaster_API.Domain.Entities;
using LocationMaster_API.Domain.UnitOfWork;

namespace LocationMaster_API
{
    public class Exemples
    {
/*        private readonly LocationMasterContext _locationMasterContext;
        public Exemples(LocationMasterContext context)
        {
            _locationMasterContext = context;
        }*/
        public void test()
        {
/*            using var unitOfWork = new UnitOfWork(_locationMasterContext);

            unitOfWork.Users.Add(User.Create("a", "sda", "dad", "dsa", "sd"));*/
            //            var user = unitOfWork.Users.Find(e => e.Username == "das").First();
            //            unitOfWork.Users.Remove(user);



            //            unitOfWork.Locations.Add(Place.);
            //            unitOfWork.Ticket.Add(new User());
            //            unitOfWork.Locations.Add(new Location());   
            //            unitOfWork.Locations.AddRange(new List<Location>{new Location()});
            //
            //            var foundPlaces = unitOfWork.Locations.Find(x => x.id > 1).ToList();
            //            unitOfWork.Locations.Remove(foundPlaces[0]);
            //            foundPlaces.RemoveAt(0);
            //            unitOfWork.Locations.RemoveRange(foundPlaces);
            //
            //            var bestPlaces = unitOfWork.Locations.GetBestPlaces(2);
            //
            //            unitOfWork.Users.Add(new User());
            //

            //            unitOfWork.Complete();
        }
    }
}