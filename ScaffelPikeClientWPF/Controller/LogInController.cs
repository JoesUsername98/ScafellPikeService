﻿using System;
using System.Windows.Threading;
using ScafellPikeClientWPF.Models;

namespace ScafellPikeClientWPF.Controller
{
  public class LogInController
  {
    private readonly ILogInView _view;
    private LogInModel _model { get; set; }
    public LogInController(ILogInView view, LogInModel model)
    {
      _view = view;
      _model = model;
      view.SetController(this);
    }

    internal void ViewOpened()
    {
      ClientRefs.Log.Information(_view.GetType().Name, "Opening form");
      InitializeTimer();
      HeartbeatManagerClientSide.TryEstablishConnectionAsync();
    }
    private void InitializeTimer()
    {
      DispatcherTimer dispatcherTimer = new DispatcherTimer();
      dispatcherTimer.Interval = new TimeSpan(5000);
      dispatcherTimer.Tick += new EventHandler(RefreshConnectionLabel);
      dispatcherTimer.IsEnabled= true;
    }
    private void RefreshConnectionLabel(object sender, EventArgs e)
    {
      UpdateConnectionCount();
    }
    internal void ViewClosed()
    {
      ClientRefs.Log.Information(_view.GetType().Name, "Closing form");
    }
    internal void UpdateConnectionCount()
    {
      LoadViewIntoModel();
      _view.Connections = $"#Clients: {_model.Connections}";
    }
    private void LoadViewIntoModel()
    {
      _model = new LogInModel(_view.Username, _view.Password, HeartbeatManagerClientSide.Connections.Count);
    }
    internal void LogIn()
    {
      LoadViewIntoModel();

      if (ClientRefs.User != null)
      {
        ClientRefs.Log.Information("buttonLogIn_ClickAsync",
          $"Client already logged int as {ClientRefs.User.FirstName} {ClientRefs.User.Surname}");
        //MessageBox.Show($"You are already logged in as {ClientRefs.User.FirstName} {ClientRefs.User.Surname}",
        //  "Log In Fault", MessageBoxButtons.OK);
        return;
      }

      var response = LogInRequester.RequestLogIn(_model.Username, _model.Password);

      if (response == null)
      {
        //MessageBox.Show("Unable to log in to server", "Log In Fault", MessageBoxButtons.OK);
        return;
      }

      if (response.SuccesfulRequest)
      {
        _view.HideView();
        //GraphView mainForm = new GraphView();
        //mainForm.ShowDialog();
      }
      //else
      //  MessageBox.Show($"Incorrect Username or Password", "Log in Failed", MessageBoxButtons.OK);
    }
    internal void HidePassword()
    {
      _view.PasswordVisible = false;
    }
    internal void ShowPassword()
    {
      _view.PasswordVisible = true;
    }
  }
}