using Application.Services.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult SendResponse(ServiceResponse response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(),
                HttpStatusCode.Unauthorized => Unauthorized(),
                HttpStatusCode.Forbidden => Forbid(),
                HttpStatusCode.NotFound => NotFound(),
                HttpStatusCode.BadRequest => BadRequest(response.Message),
                _ => StatusCode(StatusCodes.Status500InternalServerError, response.Message)
            };
        }

        protected IActionResult SendResponse<T>(ServiceResponse<T> response) where T : class
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response.ResponseContent),
                HttpStatusCode.Unauthorized => Unauthorized(),
                HttpStatusCode.Forbidden => Forbid(),
                HttpStatusCode.NotFound => NotFound(),
                HttpStatusCode.BadRequest => BadRequest(response.Message),
                _ => StatusCode(StatusCodes.Status500InternalServerError, response.Message)
            };
        }
    }
}
