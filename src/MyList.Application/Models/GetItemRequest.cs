using MediatR;

namespace MyList.Application.Models
{
    public class GetItemRequest : IRequest<GetItemResponse>
    {
        public string Id { get; set; }
    }
}
