using System;
using System.Windows;
using ScafellPikeClientWPFOld.Controller;

namespace ScafellPikeClientWPFOld.Views
{
  public partial class LogInViewWPF : Window, ILogInView
    {
    LogInController _controller;
    public LogInViewWPF()
    {
        InitializeComponent();
    }

    #region Events raised back to controller
    private void LogInWindow_Loaded(object sender, RoutedEventArgs e)
    {
      _controller.LogIn();
    }
    private void ViewPasswordImg_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
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
    private void LogInWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      _controller.ViewClosed();
    }
    #endregion
    #region ILogInView Implementation
    public string Username { get => UsernameTxtBox.Text; set => UsernameTxtBox.Text = value; }
    public string Password { get => PasswordTxtBox.Password; set => PasswordTxtBox.Password = value; } //PasswordTxtBox.SecurePassword
    public bool PasswordVisible { get => PasswordTxtBox.IsInactiveSelectionHighlightEnabled ; set => PasswordTxtBox.IsInactiveSelectionHighlightEnabled = value; }

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
