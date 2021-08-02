using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net.core.api.Models;

namespace net.core.api.Data
{
  public class AuthRepository : IAuthRepository
  {
    private readonly DataContext _context;
    public AuthRepository(DataContext context)
    {
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
        if (!this.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        {
          throw new Exception("Wrong password");
        }

        response.Data = user.Id.ToString();
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

        this.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
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

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
      using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        if (computedHash.Length != passwordHash.Length)
        {
          return false;
        }

        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != passwordHash[i])
          {
            return false;
          }
        }
        return true;
      }
    }
  }
}