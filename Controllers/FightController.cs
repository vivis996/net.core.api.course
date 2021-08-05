using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net.core.api.Dtos.Fight;
using net.core.api.Models;
using net.core.api.Services.FightService;

namespace net.core.api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FightController : ControllerBase
  {
    private readonly IFightService _fightService;

    public FightController(IFightService fightService)
    {
      this._fightService = fightService;
    }

    [HttpPost("Weapon")]
    public async Task<ActionResult<ServiceResponse<AttackResultDto>>> WeaponAttack(WeaponAttackDto request)
    {
      return Ok(await this._fightService.WeaponAttack(request));
    }
  }
}