using System;

namespace LocationMaster_API.Models.Entities
{
    public class Category
    {
        private Category()
        {
            //EF Core
        }
        public Guid CategoryId { get; private set; }
        public string Name { get; private set; }
        public Category Create(string name)
        {
            return new Category
            {
                CategoryId = Guid.NewGuid(),
                Name = name
            };
        }
    }
}