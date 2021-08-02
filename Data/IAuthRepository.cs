using System.Threading.Tasks;
using net.core.api.Models;

namespace net.core.api.Data
{
  public interface IAuthRepository
  {
    Task<ServiceResponse<int>> Register(User user, string password);
    Task<ServiceResponse<string>> Login(string username, string password);
    Task<bool> UserExists(string username);
  }
}