using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected static IActionResult BuildResponse<T>(T data, int statusCode = 200, string? message = null,
        Dictionary<string, object>? metadata = null)
    {
        var responseObject = new Dictionary<string, object?>();

        // Add data to the response object
        if (data != null)
        {
            responseObject.Add("data", data);
        }

        // Add metadata to the response object
        if (metadata != null)
        {
            responseObject.Add("metadata", metadata);
        }

        // Add message to the response object
        if (message != null)
        {
            responseObject.Add("message", message);
        }

        // Build the HTTP response
        switch (statusCode)
        {
            case 200:
                return new OkObjectResult(responseObject);
            case 201:
                return new CreatedResult("", responseObject);
            case 204:
                return new NoContentResult();
            case 400:
                return new BadRequestObjectResult(responseObject);
            case 401:
                return new UnauthorizedObjectResult(responseObject);
            case 403:
                return new ForbidResult();
            case 404:
                return new NotFoundObjectResult(responseObject);
            case 409:
                return new ConflictObjectResult(responseObject);
            case 429:
                return new StatusCodeResult(429);
            case 500:
                return new StatusCodeResult(500);
            case 503:
                return new StatusCodeResult(503);
            default:
                return new StatusCodeResult(statusCode);
        }
    }
}