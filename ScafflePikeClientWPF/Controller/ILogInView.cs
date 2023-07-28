using ScafellPikeClientWPFOld.Models;

namespace ScafellPikeClientWPFOld.Controller
{
  public interface ILogInView
  {
    void SetController(LogInController controller);
    void HideView();
    string Username { get; set; }
    string Password { get; set; }
    bool PasswordVisible { get; }
  }
}
