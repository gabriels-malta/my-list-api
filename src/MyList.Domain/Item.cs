using System;

namespace MyList.Domain
{
    public class Item
    {
        protected Item() { }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Completed { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime CompletedAt { get; private set; }

        public Item Done()
        {
            Completed = true;
            CompletedAt = DateTime.Now;
            return this;
        }

        public static Item New(string title) => New(title, null);
        public static Item New(string title, string description)
        {
            return new Item
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Description = string.IsNullOrWhiteSpace(description) ? null : description,
                Created = DateTime.Now
            };
        }
    }
}
