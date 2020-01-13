using System;
using System.Collections.Generic;
using LocationMaster_FE.Models.Responses;
using LocationMaster_FE.Services;

namespace LocationMaster_FE.ContainerState
{
    public class PagesPlacesStorage
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int RowCount { get; set; }
        public List<PlaceInfoResource> Resources { get; set; }
        public PlaceService Service { get; set; }
        public event Action OnChange;
        public event Action OnChangeContentPage;
        public PagesPlacesStorage(PlaceService service)
        {
            Resources = new List<PlaceInfoResource>();
            Service = service;
        }

        public void RegistercContentPage(Action action)
        {
            OnChangeContentPage = action;
        }
        public void SetResource(PlacesResponse response)
        {
            CurrentPage = response._pagedResult.CurrentPage;
            PageCount = response._pagedResult.PageCount;
            RowCount = response._pagedResult.RowCount;
            Resources.Clear();
            foreach (var placeInfoResource in response._pagedResult.Results)
            {
                Resources.Add(placeInfoResource);
            }
            NotifyStateChanged();
            OnChangeContentPage?.Invoke();
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}