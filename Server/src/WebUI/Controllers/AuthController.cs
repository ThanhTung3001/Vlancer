using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TSoft.TaskManagement.Application.Auth;
using TSoft.TaskManagement.Application.Auth.Commands.Authentication;

namespace TSoft.TaskManagement.WebUI.Controllers
{
    public class AuthController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] AuthApiCommands auth, CancellationToken cancellationToken)
        {
            try
            {
                var userResponse = await Mediator.Send(auth, cancellationToken);
                return Ok(userResponse);
            }
            catch (System.Exception ex)
            {

                return Unauthorized(new
                {
                    Message = ex.Message
                });
            }
        }
        [Authorize(Roles = "Users")]
        [HttpGet]
        [Route("GetMe")]
        public async Task<IActionResult> GetMe([FromQuery] GetUserInfoQueries queries)
        {
            try
            {

                return Ok(await Mediator.Send(queries));
            }
            catch (System.Exception ex)
            {

                return Unauthorized(new
                {
                    Message = ex.Message
                });
            }
        }
    }
}