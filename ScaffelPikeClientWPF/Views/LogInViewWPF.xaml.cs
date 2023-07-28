using System;
using System.Windows;
using ScafellPikeClientWPF.Controller;

namespace ScafellPikeClientWPF.Views
{
  public partial class LogInViewWPF : Window, ILogInView
    {
    LogInController _controller;
    public LogInViewWPF()
    {
        InitializeComponent();
        this.DataContext = this;
    }

    #region Events raised back to controller
    private void LogInWindow_Loaded(object sender, RoutedEventArgs e)
    {
      _controller.ViewOpened();
    }
    private void LogInWindow_LogInBtnClick(object sender, RoutedEventArgs e)
    {
      _controller.LogIn();
    }
    private void ViewPasswordImg_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      if((bool)e.NewValue)
        _controller.ShowPassword();

      if (!(bool)e.NewValue)
        _controller.HidePassword();
    }
    private void LogInWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      _controller.ViewClosed();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
      if (PasswordBox != null && !String.IsNullOrEmpty(PasswordBox.Password))
        Password = PasswordBox.Password;
    }

    private void UsernameTxtBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
      Username = UsernameTxtBox.Text;
    }

    #endregion
    #region ILogInView Implementation
    public string Username 
      { 
      get => UsernameTxtBox.Text;
      set => UsernameTxtBox.Text = value; 
    }
    public string Password 
    { get => PasswordBox.Password;
      set 
      {
        PasswordBox.Password = value;
        PasswordTxtBoxSlave.Text = PasswordBox.Password;
      }
    }
    public bool PasswordVisible { 
      get => PasswordBox.IsVisible ;
      set 
      {
        PasswordTxtBoxSlave.Visibility = value ? Visibility.Visible : Visibility.Hidden;
        PasswordBox.Visibility = value ? Visibility.Hidden : Visibility.Visible;
      }
    }
    public string Connections { get => ConnectionsLbl.Content.ToString(); set => ConnectionsLbl.Content = value; }

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
