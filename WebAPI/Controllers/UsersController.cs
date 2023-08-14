using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getDTOById")]
        public IActionResult GetDTOById(int id)
        {
            var result = _userService.GetDtoById(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("updateFirstAndLastName")]
        public IActionResult UpdateFirstAndLastName(UpdateFirstAndLastNameDto updateFirstAndLastNameDto)
        {
            var result = _userService.UpdateFirstAndLastName(updateFirstAndLastNameDto);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("updateEmail")]
        public IActionResult UpdateEmail(UpdateEmailDto updateEmailDto)
        {
            var result = _userService.UpdateEmail(updateEmailDto);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}
