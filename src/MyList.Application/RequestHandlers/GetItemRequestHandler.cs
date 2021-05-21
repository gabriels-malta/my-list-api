using MediatR;
using MyList.Application.Models;
using MyList.Domain.Behaviors;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Application.RequestHandlers
{
    internal class GetItemRequestHandler : IRequestHandler<GetItemRequest, GetItemResponse>
    {
        private readonly IItemLookup _lookup;

        public GetItemRequestHandler(IItemLookup lookup)
        {
            _lookup = lookup;
        }

        public async Task<GetItemResponse> Handle(GetItemRequest request, CancellationToken cancellationToken)
        {
            GetItemResponse response = new GetItemResponse { Code = "RETRIEVE_TASK" };
            var retrievedItem = await _lookup.GetById(request.Id, cancellationToken);
            if (retrievedItem != null)
            {
                response.Item = ItemResponse.New(retrievedItem.Id, retrievedItem.Title, retrievedItem.Description, retrievedItem.Completed);
                response.SetOk();
                response.Message = $"Look that!";
            }
            return response;
        }
    }
}
