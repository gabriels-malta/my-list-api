using MediatR;

namespace MyList.Application.Models
{
    public class CompleteItemRequest : IRequest<CompleteItemResponse>
    {
        public string ItemId { get; set; }
    }
}
