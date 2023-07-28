using ScafellPikeClientWPF.Models;

namespace ScafellPikeClientWPF.Controller
{
  public interface ILogInView
  {
    void SetController(LogInController controller);
    void HideView();
    string Username { get; set; }
    string Password { get; set; }
    string Connections { get; set; }
    bool PasswordVisible { get; set; }
  }
}
