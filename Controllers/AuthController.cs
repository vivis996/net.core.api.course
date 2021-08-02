using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net.core.api.Data;
using net.core.api.Dtos.User;
using net.core.api.Models;

namespace net.core.api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _authRepo;
    public AuthController(IAuthRepository authRepo)
    {
      this._authRepo = authRepo;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
    {
      var response = await this._authRepo.Register(new Models.User
      {
        Username = request.Username,
      }, request.Password);

      if (!response.Success)
      {
        return BadRequest(response);
      }
      return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
    {
      var response = await this._authRepo.Login(request.Username, request.Password);

      if (!response.Success)
      {
        return BadRequest(response);
      }
      return Ok(response);
    }
  }
}