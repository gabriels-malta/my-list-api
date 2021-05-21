using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyList.Application.Models;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MyList.Api.Controllers
{
    public class MyListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MyListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public virtual async Task<IActionResult> Execute<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _mediator.Send(request, cancellationToken);
                if (response is ServiceResponse serviceResponse)
                {
                    if (serviceResponse.Success)
                        return Ok(response);

                    return BadRequest(response);
                }
                return BadRequest("Something went wrong");
            }
            catch (System.Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)HttpStatusCode.InternalServerError };
            }
        }
    }
}
