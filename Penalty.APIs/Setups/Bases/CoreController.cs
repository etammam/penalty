using System.Collections.Generic;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Penalty.Application.Common.Responses;
using Penalty.Application.Common.Responses.Models;
using Penalty.Crosscut.Constants;

namespace Penalty.APIs.Setups.Bases
{
    public class CoreController : Controller
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
        public ObjectResult NewResult<T>(OutputResponse<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK: //200
                    return new OkObjectResult(response);
                case HttpStatusCode.Created: //201
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Forbidden: //403
                    return new UnauthorizedObjectResult(new OutputResponse<T>()
                    {
                        Errors = new List<ErrorModel>()
                        {
                            new ErrorModel()
                            {
                                ErrorCode = ValidationErrorCodes.Unauthorized.ToString(),
                                Message = ResponseMessages.Unauthorized,
                                Property = "Overall"
                            }
                        },
                        Message = ResponseMessages.Unauthorized,
                        Success = false
                    });
                case HttpStatusCode.BadRequest: //400
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound: //404
                    return new NotFoundObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
    }
}
