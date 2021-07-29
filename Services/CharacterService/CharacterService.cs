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

    public async Task<List<Character>> AddNewObject(Character newCharacter)
    {
      characters.Add(newCharacter);
      return characters;
    }

    public async Task<List<Character>> GetAll()
    {
      return characters;
    }

    public async Task<Character> GetById(int id)
    {
      return characters.FirstOrDefault(c => c.Id == id);
    }
  }
}