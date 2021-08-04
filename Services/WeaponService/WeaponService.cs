using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using net.core.api.Data;
using net.core.api.Dtos.Character;
using net.core.api.Dtos.Weapon;
using net.core.api.Models;

namespace net.core.api.Services.WeaponService
{
  public class WeaponService : IWeaponService
  {
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    public WeaponService(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
      this._mapper = mapper;
      this._httpContextAccessor = httpContextAccessor;
      this._context = context;

    }
    private int GetUserId() => int.Parse(this._httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    public async Task<ServiceResponse<GetCharacterDto>> AddNewObject(AddWeaponDto newWeapon)
    {
      var response = new ServiceResponse<GetCharacterDto>();
      try
      {
        var character = await this._context.Characters
                        .FirstOrDefaultAsync(c => c.Id == newWeapon.CharacterId && c.User.Id == this.GetUserId());
        if (character == null)
        {
          throw new Exception("Character not found");
        }
        var weapon = new Weapon
        {
          Name = newWeapon.Name,
          Damage = newWeapon.Damage,
          Character = character,
        };
        weapon.Character = character;

        this._context.Weapons.Add(weapon);
        await this._context.SaveChangesAsync();
        response.Data = this._mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception ex)
      {
        response.Success = false;
        response.Message = ex.Message;
      }

      return response;
    }
  }
}