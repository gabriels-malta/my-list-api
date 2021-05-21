using MediatR;
using MyList.Application.Models;
using MyList.Domain;
using MyList.Domain.Behaviors;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Application.RequestHandlers
{
    internal class CompleteRequestHandler : IRequestHandler<CompleteItemRequest, CompleteItemResponse>
    {
        private readonly IItemPersistence _persistence;
        private readonly IItemLookup _lookup;

        public CompleteRequestHandler(IItemPersistence persistence,
                                      IItemLookup lookup)
        {
            _persistence = persistence;
            _lookup = lookup;
        }

        public async Task<CompleteItemResponse> Handle(CompleteItemRequest request, CancellationToken cancellationToken)
        {
            CompleteItemResponse response = new CompleteItemResponse
            {
                Code = "COMPLETE_ITEM"
            };
            Item item = await _lookup.GetById(request.ItemId, cancellationToken);
            if (item == null)
            {
                response.Message = "Task not found";
                return response;
            }

            item.Done();
            int result = await _persistence.Update(item, cancellationToken);
            if (result == 0)
            {
                response.Message = "Unable to complete the task";
                return response;
            }

            response.SetOk();
            response.Message = "Task was completed";
            
            return response;
        }
    }
}
