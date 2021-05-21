using MediatR;
using MyList.Application.Models;
using MyList.Domain.Behaviors;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Application.RequestHandlers
{
    internal class GetCompletedItemsRequestHandler : IRequestHandler<GetCompletedRequest, GetAllItemsResponse>
    {
        private readonly IItemLookup _lookup;

        public GetCompletedItemsRequestHandler(IItemLookup lookup)
        {
            _lookup = lookup;
        }

        public async Task<GetAllItemsResponse> Handle(GetCompletedRequest request, CancellationToken cancellationToken)
        {
            GetAllItemsResponse response = new GetAllItemsResponse { Code = "GET_COMPLETED_TASKS" };

            var listOfItems = await _lookup.GetCompleted(cancellationToken);
            if (listOfItems.Any())
            {
                foreach (var item in listOfItems)
                    response.Items.Add(ItemResponse.New(item.Id, item.Title, item.Description, item.Completed));


                response.TotalItems = listOfItems.Count();
                response.SetOk();
                response.Message = $"{response.TotalItems} itens were found";
            }
            return response;
        }
    }
}
