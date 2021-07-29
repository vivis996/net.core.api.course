using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using net.core.api.Models;

namespace net.core.api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterController : ControllerBase
  {
    public static List<Character> characters = new List<Character>
    {
        new Character(),
        new Character { Id = 1, Name = "Yoda", },
    };

    [HttpGet]
    [Route("GetAll")]
    public ActionResult<List<Character>> GetAll()
    {
      return Ok(characters);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<Character> GetSingle(int id)
    {
      return Ok(characters.FirstOrDefault(c => c.Id == id));
    }

    [HttpPost]
    public ActionResult<Character> AddCharacter(Character newCharacter)
    {
        characters.Add(newCharacter);
      return Ok(characters);
    }
  }
}