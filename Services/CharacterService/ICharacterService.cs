using System.Collections.Generic;
using net.core.api.Models;

namespace net.core.api.Services.CharacterService
{
  public interface ICharacterService
  {
    List<Character> GetAll();
    Character GetById(int id);
    List<Character> AddNewObject(Character newCharacter);
  }
}