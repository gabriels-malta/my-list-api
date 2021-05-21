using MediatR;

namespace MyList.Application.Models
{
    public class NewItemRequest:IRequest<NewItemResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
