using MediatR;

namespace MyList.Application.Models
{
    public class GetCompletedRequest : IRequest<GetAllItemsResponse> { }
}
