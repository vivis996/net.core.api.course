using System.Collections.Generic;
using net.core.api.Dtos.Skill;
using net.core.api.Dtos.Weapon;
using net.core.api.Models;

namespace net.core.api.Dtos.Character
{
  public class GetCharacterDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public int Strength { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public RpgClass Class { get; set; }
    public GetWeaponDto Weapon { get; set; }
    public List<GetSkillDto> Skills { get; set; }
  }
}