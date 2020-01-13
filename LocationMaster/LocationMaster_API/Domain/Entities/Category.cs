using System;

namespace LocationMaster_API.Domain.Entities
{
    public class Category
    {
        private Category()
        {
            //EF Core
        }
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public static Category Create(string name)
        {
            return new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = name
            };
        }
    }
}