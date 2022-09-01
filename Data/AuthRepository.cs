using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using net.core.api.Models;

namespace net.core.api.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;
    private readonly IConfiguration _configuration;
    public AuthRepository(DataContext context, IConfiguration configuration)
    {
      this._configuration = configuration;
      this._context = context;
    }

    public async Task<ServiceResponse<string>> Login(string username, string password)
    {
      var response = new ServiceResponse<string>();
      try
      {
        var user = await this._context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));
        if (user == null)
        {
          throw new Exception("User not found.");
        }
        if (!Utility.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
          throw new Exception("Wrong password");
        }

        response.Data = this.CreateToken(user);
      }
      catch (Exception ex)
      {
        response.Success = false;
        response.Message = ex.Message;
      }

      return response;
    }

    public async Task<ServiceResponse<int>> Register(User user, string password)
    {
      var response = new ServiceResponse<int>();
      try
      {
        if (await this.UserExists(user.Username))
        {
          throw new Exception("User already exists.");
        }

        Utility.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        this._context.Users.Add(user);
        await this._context.SaveChangesAsync();
        response.Data = user.Id;
      }
      catch (Exception ex)
      {
        response.Success = false;
        response.Message = ex.Message;
      }

      return response;
    }

    public async Task<bool> UserExists(string username)
    {
      return await this._context.Users.AnyAsync(x => x.Username.ToLower().Equals(username.ToLower()));
    }

    private string CreateToken(User user)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Role, user.Role),
      };

      var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(this._configuration.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var token = new JwtSecurityToken
      (
        claims: claims,
        expires: DateTime.Now.AddDays(1),
        signingCredentials: creds
      );

      var jwt = new JwtSecurityTokenHandler().WriteToken(token);

      return jwt;
    }
  }
}