using System.Collections.Generic;
using System.Threading.Tasks;
using net.core.api.Dtos.Character;
using net.core.api.Models;

namespace net.core.api.Services.CharacterService
{
  public interface ICharacterService
  {
    Task<ServiceResponse<List<GetCharacterDto>>> GetAll();
    Task<ServiceResponse<GetCharacterDto>> GetById(int id);
    Task<ServiceResponse<List<GetCharacterDto>>> AddNewObject(AddCharacterDto newCharacter);
  }
}