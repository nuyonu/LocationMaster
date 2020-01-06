using System;
using System.Collections.Generic;

namespace LocationMaster_FE.ContainerState
{
    public class SearchState
    {
        public int RangeOption { get; private set; }
        public List<string> Category { get; private set; }
        public int Rating { get; private set; }
        public event Action OnChange;
        public string Search { get; private set; }

        public SearchState()
        {
            Category = new List<string>();
        }

        public void SetPage(int page)
        {
            NotifyStateChanged();
        }

        public void SetSearch(string search)
        {
            Search = search;
            NotifyStateChanged();
        }
  
        public void SetCategory(string category)
        {
            if (Category.Contains(category))
                Category.Remove(category);
            else
                Category.Add(category);
            NotifyStateChanged();
        }

        public void SetRating(int rating)
        {
            Rating = rating;
            NotifyStateChanged();
        }

        public void SetRange(int range)
        {
            RangeOption = range;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}