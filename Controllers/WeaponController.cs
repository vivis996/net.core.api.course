using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net.core.api.Dtos.Character;
using net.core.api.Dtos.Weapon;
using net.core.api.Models;
using net.core.api.Services.WeaponService;

namespace net.core.api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class WeaponController : ControllerBase
  {
    private readonly IWeaponService _weaponService;
    public WeaponController(IWeaponService weaponService)
    {
      this._weaponService = weaponService;
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddWeapon(AddWeaponDto newWeapon)
    {
      var response = await this._weaponService.AddNewObject(newWeapon);
      if (!response.Success)
      {
        return BadRequest(response);
      }
      return Ok(response);
    }
  }
}