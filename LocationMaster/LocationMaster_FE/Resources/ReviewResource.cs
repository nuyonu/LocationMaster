namespace LocationMaster_FE.Resources
{
    public class ReviewResource
    {
        public int Ratting { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string Text { get; set; }

        public static ReviewResource CreateDefault()
        {
            return new ReviewResource()
            {
                Name = "owner name",
                Ratting = 3,
                PhotoUrl = "images/index-page/first-image.webp",
                Text =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non consectetur purus. Morbi tempor ultricies quam. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Curabitur ac tristique augue. Fusce rutrum, arcu at faucibus gravida, purus nunc aliquet tellus, vel scelerisque felis ligula sed neque. Mauris ornare turpis quis urna feugiat placerat. Etiam maximus enim et turpis egestas convallis. Sed sodales tellus purus, eu volutpat tortor sagittis a. Fusce ac vehicula tortor."
            };
        }
    }
}