using System;
using System.Windows.Forms;

namespace ScaffelPikeClient
{
  public partial class LogInScreen : Form
  {
    public LogInScreen()
    {
      InitializeComponent();
      InitializeTiner();
      ClientRefs.Log.Information("LogInScreen", "Initialized Logger");
      HeartbeatManagerClientSide.TryEstablishConnectionAsync();
    }

    private void InitializeTiner()
    {
      Timer t1 = new Timer();
      t1.Interval = 5000;
      t1.Tick += new EventHandler(RefreshConnectionLabel);
      t1.Enabled = true;
    }

    private void RefreshConnectionLabel(object sender, EventArgs e)
    {
        labelConnections.Text = $"Connections Available : {HeartbeatManagerClientSide.Connections.Count}";
    }

    private void buttonLogIn_ClickAsync(object sender, EventArgs e)
    {
      if(ClientRefs.User != null)
      {
        ClientRefs.Log.Information("buttonLogIn_ClickAsync",
          $"Client already logged int as {ClientRefs.User.FirstName} {ClientRefs.User.Surname}");
        MessageBox.Show($"You are already logged in as {ClientRefs.User.FirstName} {ClientRefs.User.Surname}",
          "Log In Fault", MessageBoxButtons.OK);
        return;
      }

      var response = LogInRequester.RequestLogIn(textBoxUsername.Text, textBoxPassword.Text);

      if (response == null)
      {
        MessageBox.Show("Unable to log in to server", "Log In Fault", MessageBoxButtons.OK);
        return;
      }

      var adminMessage = Environment.NewLine + $"You{((response.Admin)?"":" do not")} have admin privileges";

      if (response.SuccesfulRequest)
      {
        this.Hide();
        MainForm mainForm = new MainForm();
        mainForm.ShowDialog();
      }
      else
        MessageBox.Show($"Incorrect Username or Password", "Log in Failed", MessageBoxButtons.OK);
    }

    private void pictureBoxViewPassword_MouseHover(object sender, EventArgs e)
    {
      textBoxPassword.UseSystemPasswordChar = false;
    }

    private void pictureBoxViewPassword_MouseLeave(object sender, EventArgs e)
    {
      textBoxPassword.UseSystemPasswordChar = true;
    }

    private void LogInScreen_FormClosed(object sender, FormClosedEventArgs e)
    {
      ClientRefs.Log.Information("LogInScreen_FormClosed", "Closing form");
    }

    private void LogInScreen_Load(object sender, EventArgs e)
    {
      ClientRefs.Log.Information("LogInScreen_Load", "Opening form");
    }
  }
}
