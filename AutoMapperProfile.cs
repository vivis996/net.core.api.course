using AutoMapper;
using net.core.api.Dtos.Character;
using net.core.api.Dtos.Fight;
using net.core.api.Dtos.Skill;
using net.core.api.Dtos.Weapon;
using net.core.api.Models;

namespace net.core.api
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      this.CreateMap<Character, GetCharacterDto>();
      this.CreateMap<AddCharacterDto, Character>();
      this.CreateMap<Weapon, GetWeaponDto>();
      this.CreateMap<Skill, GetSkillDto>();
      this.CreateMap<Character, HighscoreDto>();
    }
  }
}