using System.Collections.Generic;
using System.Threading.Tasks;
using net.core.api.Models;

namespace net.core.api.Services.CharacterService
{
  public interface ICharacterService
  {
    Task<ServiceResponse<List<Character>>> GetAll();
    Task<ServiceResponse<Character>> GetById(int id);
    Task<ServiceResponse<List<Character>>> AddNewObject(Character newCharacter);
  }
}