using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
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