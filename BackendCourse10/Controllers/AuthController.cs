using BackendCourse10.Dto;
using BackendCourse10.GenericResponse;
using BackendCourse10.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BackendCourse10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            try
            {
                var result = await _authService.LoginUser(userDto);

                if (result.Item1 == 0)
                {
                    return NotFound(ResponseResult<string>.Failure(null, result.Item2));
                }

                if (result.Item1 == 1)
                {
                    return BadRequest(ResponseResult<string>.Failure(null, result.Item2));
                }

                return Ok(ResponseResult<string>.Sucsess(null, result.Item2));

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
        {
            try
            {
                var result = await _authService.RegisterUser(userDto);
                if (result.Item1 == 0)
                {
                    return Ok(ResponseResult<string>.Failure(null, result.Item2));
                }

                return Ok(ResponseResult<string>.Sucsess(null, result.Item2));
            }
            catch (Exception)
            {

                throw;
            }
        }
}}
