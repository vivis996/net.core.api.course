using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net.core.api.Data;
using net.core.api.Dtos.Fight;
using net.core.api.Models;

namespace net.core.api.Services.FightService
{
  public class FightService : IFightService
  {
    private readonly DataContext _context;
    public FightService(DataContext context)
    {
      this._context = context;
    }

    public async Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request)
    {
      var response = new ServiceResponse<AttackResultDto>();
      try
      {
        var attacker = await this._context.Characters
                .Include(c => c.Weapon)
                .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
        var opponent = await this._context.Characters
                .FirstOrDefaultAsync(c => c.Id == request.OpponentId);

        var damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
        damage -= new Random().Next(opponent.Defense);

        if (damage > 0)
        {
          opponent.HitPoints -= damage;
        }
        if (opponent.HitPoints <= 0)
        {
          response.Message = $"{opponent.Name} has been defeated!";
        }

        await this._context.SaveChangesAsync();
        response.Data = new AttackResultDto
        {
          Attacker = attacker.Name,
          AttackerHP = attacker.HitPoints,
          Opponent = opponent.Name,
          OpponentHP = opponent.HitPoints,
          Damage = damage,
        };
      }
      catch (Exception ex)
      {
        response.Success = false;
        response.Message = ex.Message;
      }

      return response;
    }

    public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request)
    {
      var response = new ServiceResponse<AttackResultDto>();
      try
      {
        var attacker = await this._context.Characters
                .Include(c => c.Skills)
                .FirstOrDefaultAsync(c => c.Id == request.AttackerId);
        var opponent = await this._context.Characters
                .FirstOrDefaultAsync(c => c.Id == request.OpponentId);

        var skill = attacker.Skills.FirstOrDefault(s => s.Id == request.SkillId);
        if (skill == null)
        {
          throw new Exception($"{attacker.Name} doesn't know this skill.");
        }

        var damage = skill.Damage + (new Random().Next(attacker.Intelligence));
        damage -= new Random().Next(opponent.Defense);

        if (damage > 0)
        {
          opponent.HitPoints -= damage;
        }
        if (opponent.HitPoints <= 0)
        {
          response.Message = $"{opponent.Name} has been defeated!";
        }

        await this._context.SaveChangesAsync();
        response.Data = new AttackResultDto
        {
          Attacker = attacker.Name,
          AttackerHP = attacker.HitPoints,
          Opponent = opponent.Name,
          OpponentHP = opponent.HitPoints,
          Damage = damage,
        };
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