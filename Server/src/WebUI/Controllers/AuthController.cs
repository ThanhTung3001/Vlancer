using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSoft.TaskManagement.Application.Auth.Commands.Authentication;
using TSoft.TaskManagement.Application.Auth.Commands.ForgotPassword;
using TSoft.TaskManagement.Application.Auth.Commands.Register;
using TSoft.TaskManagement.Application.Auth.Queries.UserInfo;

namespace WebUI.Controllers
{
    public class AuthController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] AuthApiCommands auth,
            CancellationToken cancellationToken)
        {
            try
            {
                var userResponse = await Mediator.Send(auth, cancellationToken);
                return Ok(userResponse);
            }
            catch (System.Exception ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetMe")]
        public async Task<IActionResult> GetMe()
        {
            try
            {
                return Ok(await Mediator.Send(new GetUserInfoQueries()));
            }
            catch (System.Exception ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var userCreate = await Mediator.Send(request, cancellationToken);
                return BuildResponse(data: userCreate, statusCode: 200);
            }
            catch (Exception e)
            {
                return BuildResponse<object>(message: e.Message, statusCode: 400, data: null);
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] RequestForgotPassword command,
            CancellationToken cancellationToken)
        {
            try
            {
                var result = await Mediator.Send(command, cancellationToken);
                return BuildResponse(statusCode: 200, data: result,
                    message: "Check your email, we just send mail change password");
            }
            catch (Exception e)
            {
                return BuildResponse<object>(data: null, statusCode: 400, message: e.Message);
            }
        }
    }
}