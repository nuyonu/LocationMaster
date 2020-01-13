using System;

namespace LocationMaster_FE.ContainerState
{
    public class ProfileImageState
    {
        public event Action OnChangeContentPage;

        public string ImgSrc { get; set; }

        public void RegistercContentPage(Action action)
        {
            OnChangeContentPage = action;
        }

        public void NotifyStateChanged() { 
            OnChangeContentPage?.Invoke();
        }
    }
}
