using System.Collections.Generic;
using System.Threading.Tasks;
using net.core.api.Models;

namespace net.core.api.Services.CharacterService
{
  public interface ICharacterService
  {
    Task<List<Character>> GetAll();
    Task<Character> GetById(int id);
    Task<List<Character>> AddNewObject(Character newCharacter);
  }
}