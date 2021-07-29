using System.Collections.Generic;
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
        new Character { Name = "Yoda", },
    };

    [HttpGet]
    [Route("GetAll")]
    public ActionResult<List<Character>> GetAll()
    {
      return Ok(characters);
    }

    [HttpGet]
    public ActionResult<Character> GetSingle()
    {
      return Ok(characters[0]);
    }
  }
}