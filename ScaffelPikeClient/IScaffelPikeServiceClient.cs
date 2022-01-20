using System.Threading.Tasks;
using ScaffelPikeContracts;

namespace ScaffelPikeClient
{
  public interface IScaffelPikeServiceClient
  {
    Task<PasswordDto> LogIn(string username, string password);
  }
}