using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using net.core.api.Data;
using net.core.api.Dtos.Character;
using net.core.api.Models;

namespace net.core.api.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CharacterService(IMapper mapper, DataContext context)
    {
      this._mapper = mapper;
      this._context = context;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddNewObject(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var character = this._mapper.Map<Character>(newCharacter);
      this._context.Characters.Add(character);
      await this._context.SaveChangesAsync();
      serviceResponse.Data = this._context.Characters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteObject(int id)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      try
      {
        var character = await this._context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null)
        {
          throw new NullReferenceException("Character not found.");
        }
        this._context.Characters.Remove(character);
        await this._context.SaveChangesAsync();

        serviceResponse.Data = this._context.Characters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAll(int userId)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var dbCharacters = await this._context.Characters.Where(c => c.User.Id == userId).ToListAsync();
      serviceResponse.Data = dbCharacters.Select(c => this._mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      var dbCharacter = await this._context.Characters.FirstOrDefaultAsync(c => c.Id == id);
      serviceResponse.Data = this._mapper.Map<GetCharacterDto>(dbCharacter);
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> UpdateObject(UpdateCharacterDto updateCharacter)
    {
      var serviceResponse = new ServiceResponse<GetCharacterDto>();
      try
      {
        var character = await this._context.Characters.FirstOrDefaultAsync(c => c.Id == updateCharacter.Id);
        if (character == null)
        {
          throw new NullReferenceException("Character not found.");
        }
        character.Name = updateCharacter.Name;
        character.HitPoints = updateCharacter.HitPoints;
        character.Strength = updateCharacter.Strength;
        character.Defense = updateCharacter.Defense;
        character.Intelligence = updateCharacter.Intelligence;
        character.Class = updateCharacter.Class;

        await this._context.SaveChangesAsync();

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
      }
      catch (Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }
  }
}