using System.Threading.Tasks;
using net.core.api.Dtos.Character;
using net.core.api.Dtos.Weapon;
using net.core.api.Models;

namespace net.core.api.Services.WeaponService
{
  public interface IWeaponService
  {
    Task<ServiceResponse<GetCharacterDto>> AddNewObject(AddWeaponDto newWeapon);
  }
}