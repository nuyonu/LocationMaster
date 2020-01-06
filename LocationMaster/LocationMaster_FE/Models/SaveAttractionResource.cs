namespace LocationMaster_FE.Models
{
    public class SaveAttractionResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        public SaveAttractionResource()
        {
            Photo = new byte[0];
        }
    }
}