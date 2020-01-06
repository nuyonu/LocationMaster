using System;
using System.Collections.Generic;
using LocationMaster_FE.Services;

namespace LocationMaster_FE.ContainerState
{
    public class Storage
    {
        public PagesPlacesStorage PlaceInfo { get;  private set; }
        public SearchStorage SearchPlace { get; private set; }
        
        public Storage(PlaceService service)
        {
            PlaceInfo=new PagesPlacesStorage(service:service);
            SearchPlace=new SearchStorage();
        }
    }
}