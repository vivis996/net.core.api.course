using System.Collections.Generic;

namespace net.core.api.Dtos.Fight
{
  public class FightResultDto
  {
    public List<string> Log { get; set; }
    public FightResultDto()
    {
      this.Log = new List<string>();
    }
  }
}