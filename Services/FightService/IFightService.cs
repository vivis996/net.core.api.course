using System.Threading.Tasks;
using net.core.api.Dtos.Fight;
using net.core.api.Models;

namespace net.core.api.Services.FightService
{
  public interface IFightService
  {
    Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
  }
}