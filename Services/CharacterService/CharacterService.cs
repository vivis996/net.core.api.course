using System.Collections.Generic;
using System.Linq;
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
    
    public List<Character> AddNewObject(Character newCharacter)
    {
      characters.Add(newCharacter);
      return characters;
    }

    public List<Character> GetAll()
    {
      return characters;
    }

    public Character GetById(int id)
    {
      return characters.FirstOrDefault(c => c.Id == id);
    }
  }
}