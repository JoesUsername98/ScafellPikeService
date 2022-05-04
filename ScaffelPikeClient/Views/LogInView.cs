using System;
using System.Windows.Forms;
using ScaffelPikeClient.Controller;
using ScaffelPikeClient.Models;

namespace ScaffelPikeClient.View
{
  public partial class LogInView : Form, ILogInView
  {

    LogInController _controller;

    public string Username { get => textBoxUsername.Text; set => textBoxUsername.Text= value; }
    public string Password { get => textBoxPassword.Text; set => textBoxPassword.Text = value; }
    public string Connections { get => labelConnections.Text; set => labelConnections.Text = value; }
    public bool PasswordVisible { get => !textBoxPassword.UseSystemPasswordChar; set => textBoxPassword.UseSystemPasswordChar = !value; }

    public LogInView()
    {
      InitializeComponent();
    }

    #region Events raised back to controller
    private void buttonLogIn_ClickAsync(object sender, EventArgs e)
    {
      _controller.LogIn();
    }
    private void pictureBoxViewPassword_MouseHover(object sender, EventArgs e)
    {
      _controller.ShowPassword();
    }
    private void pictureBoxViewPassword_MouseLeave(object sender, EventArgs e)
    {
      _controller.HidePassword();
    }
    private void LogInScreen_Load(object sender, EventArgs e)
    {
      _controller.ViewOpened();
    }
    private void LogInScreen_FormClosed(object sender, FormClosedEventArgs e)
    {
      _controller.ViewClosed();
    }
    #endregion
    #region ILogInView Implementation
    public void SetController(LogInController controller)
    {
      _controller = controller;
    }

    public void HideView()
    {
      Hide();
    }
    #endregion
  }
}
