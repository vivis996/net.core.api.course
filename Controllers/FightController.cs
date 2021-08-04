using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net.core.api.Services.FightService;

namespace net.core.api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("[controller]")]
  public class FightController : ControllerBase
  {
    private readonly IFightService _fightService;

    public FightController(IFightService fightService)
    {
      this._fightService = fightService;
    }
  }
}