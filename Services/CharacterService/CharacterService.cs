using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using net.core.api.Dtos.Character;
using net.core.api.Models;

namespace net.core.api.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    public static List<Character> characters = new List<Character>
    {
      new Character(),
      new Character { Id = 1, Name = "Yoda", },
    };
    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
      this._mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddNewObject(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var character = this._mapper.Map<Character>(newCharacter);
      character.Id = characters.Max(c => c.Id) + 1;
      characters.Add(character);
      serviceResponse.Data = characters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll()
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      serviceResponse.Data = characters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      serviceResponse.Data = this._mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
      return serviceResponse;
    }
  }
}