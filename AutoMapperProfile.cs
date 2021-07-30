using AutoMapper;
using net.core.api.Dtos.Character;
using net.core.api.Models;

namespace net.core.api
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      this.CreateMap<Character, GetCharacterDto>();
      this.CreateMap<AddCharacterDto, Character>();
    }
  }
}