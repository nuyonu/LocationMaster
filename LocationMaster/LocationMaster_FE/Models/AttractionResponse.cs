using System;

namespace LocationMaster_FE.Models
{
    public class AttractionResponse
    {
        public Guid AttractionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }
        public bool Deleted { get; set; }

        public string GetImage()
        {
            return Photo.Length == 0 ? "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAGQAAABkCAYAAABw4pVUAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAACxMAAAsTAQCanBgAAAAmdEVYdFNvZnR3YXJlAEFkb2JlIFBob3Rvc2hvcCBDUzYgKFdpbmRvd3MpgBX56wAAAAd0SU1FB+IJEwoCHh1KUB4AAAAhdEVYdENyZWF0aW9uIFRpbWUAMjAxODowOToxOCAxMzo0OTozMTm6644AAAEDSURBVHhe7dExEcAwEMCwb/gzaK9UkyUgPEiLAfj5/ncPGeuWCENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDIkxJMaQGENiDEmZOeJnA5zYkklzAAAAAElFTkSuQmCC" : $"data:image/jpg;base64,{Convert.ToBase64String(Photo)}";
        }

        public string GetDescription()
        {
            var temp = Description;
            for (var i = 130; i < Description.Length; i += 130)
                temp = temp.Insert(i, "\n");
            return temp;
        }

        public AttractionResponse()
        {
        }
    }
}