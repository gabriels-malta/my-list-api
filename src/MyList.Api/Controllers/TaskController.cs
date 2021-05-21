using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : MyListController
    {
        public TaskController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return await Execute<GetAllItemsRequest, GetAllItemsResponse>(new GetAllItemsRequest(), cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id, CancellationToken cancellationToken)
        {
            return await Execute<GetItemRequest, GetItemResponse>(new GetItemRequest() { Id = id }, cancellationToken);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Createtem([FromBody] NewItemRequest request, CancellationToken cancellationToken)
        {
            return await Execute<NewItemRequest, NewItemResponse>(request, cancellationToken);
        }

        [HttpPatch("done/{id}")]
        public async Task<IActionResult> CompleteItem([FromRoute] string id, CancellationToken cancellationToken)
        {
            return await Execute<CompleteItemRequest, CompleteItemResponse>(new CompleteItemRequest() { ItemId = id }, cancellationToken);
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedItems(CancellationToken cancellationToken)
        {
            return await Execute<GetCompletedRequest, GetAllItemsResponse>(new GetCompletedRequest(), cancellationToken);
        }

    }
}
