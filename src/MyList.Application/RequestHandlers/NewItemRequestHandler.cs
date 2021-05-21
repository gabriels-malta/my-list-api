using MediatR;
using MyList.Application.Models;
using MyList.Domain;
using MyList.Domain.Behaviors;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Application.RequestHandlers
{
    internal class NewItemRequestHandler : IRequestHandler<NewItemRequest, NewItemResponse>
    {
        private readonly IItemPersistence _persistence;

        public NewItemRequestHandler(IItemPersistence persistence)
        {
            _persistence = persistence;
        }

        public async Task<NewItemResponse> Handle(NewItemRequest request, CancellationToken cancellationToken)
        {
            NewItemResponse response = new NewItemResponse
            {
                Code = "ADD_NEW_TASK"
            };

            Item item = Item.New(request.Title, request.Description);

            var itemId = await _persistence.Create(item, cancellationToken);
            if (string.IsNullOrWhiteSpace(itemId))
            {
                response.Message = "Fail when creating a new task";
                return response;
            }

            response.SetOk();
            response.Message = "New task was successfully created";
            response.ItemId = itemId;

            return response;
        }
    }
}
