using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using net.core.api.Models;
using net.core.api.Services.CharacterService;

namespace net.core.api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
      this._characterService = characterService;
    }

    [HttpGet]
    [Route("GetAll")]
    public ActionResult<List<Character>> GetAll()
    {
      return Ok(this._characterService.GetAll());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Character> GetSingle(int id)
    {
      return Ok(this._characterService.GetById(id));
    }

    [HttpPost]
    public ActionResult<Character> AddCharacter(Character newCharacter)
    {
      return Ok(this._characterService.AddNewObject(newCharacter));
    }
  }
}