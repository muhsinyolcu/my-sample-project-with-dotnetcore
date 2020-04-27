using Common.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Product.WebApi.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public IActionResult HttpEntity<T>(ServiceResult<T> response)
        {
            switch (response.StatusCode)
            {
                case 0:
                case 200:
                    return Ok(response);
                case 1: return StatusCode(500, response);
                case 404: return NotFound(response);
                case 400: return BadRequest(response);
                default: throw new ApplicationException();
            }
        }
    }
}