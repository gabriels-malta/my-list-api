using System.Collections.Generic;

namespace MyList.Application.Models
{
    public class GetAllItemsResponse : ServiceResponse
    {
        public ICollection<ItemResponse> Items { get; set; }
        public int TotalItems { get; set; }

        public GetAllItemsResponse()
        {
            Items = new List<ItemResponse>();
        }
    }
    public struct ItemResponse
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Completed { get; private set; }

        public static ItemResponse New(string id, string title, string description, bool completed)
        {
            return new ItemResponse
            {
                Id = id,
                Title = title,
                Description = string.IsNullOrWhiteSpace(description) ? null : description,
                Completed = completed
            };
        }
    }
}
