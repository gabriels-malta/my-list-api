using MediatR;

namespace MyList.Application.Models
{
    public class GetAllItemsRequest : IRequest<GetAllItemsResponse> { }
}
