using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

    public async Task<ServiceResponse<List<Character>>> AddNewObject(Character newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<Character>>();
      characters.Add(newCharacter);
      serviceResponse.Data = characters;
      return serviceResponse ;
    }

    public async Task<ServiceResponse<List<Character>>> GetAll()
    {
      var serviceResponse = new ServiceResponse<List<Character>>();
      serviceResponse.Data = characters;
      return serviceResponse;
    }

    public async Task<ServiceResponse<Character>> GetById(int id)
    {
      var serviceResponse = new ServiceResponse<Character>();
      serviceResponse.Data = characters.FirstOrDefault(c => c.Id == id);
      return serviceResponse;
    }
  }
}