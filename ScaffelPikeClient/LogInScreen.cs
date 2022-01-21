using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaffelPikeClient
{
  public partial class LogInScreen : Form
  {
    public LogInScreen()
    {
      InitializeComponent();
      InitializeTiner();
      ClientReferences.Logger.Information("LogInScreen", "Initialized Logger");
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

    private void buttonLogIn_Click(object sender, EventArgs e)
    {
      var username = textBoxUsername.Text;
      var password = textBoxPassword.Text;

      ClientReferences.Logger.Information("buttonLogIn_Click", $"Log In Attempt with Username [{username}] Passsword [{password}]");
      
      //clean up with awiat and seperate in MVC fashion
      var outputTask = ClientReferences.ScaffelPikeChannel.LogIn(username, password);
      outputTask.Wait();
      var output = outputTask.Result;

      ClientReferences.Logger.Information("buttonLogIn_Click", $"Log In Attempt Successful {output.Success}");

      if (output.Success)
        MessageBox.Show($"Welcome {output.OtherData}", "Log in Success", MessageBoxButtons.OK);
      else
        MessageBox.Show($"Who do you think you are?", "Log in Failed", MessageBoxButtons.OK);
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
      ClientReferences.Logger.Information("LogInScreen_FormClosed", "Closing form");
    }

    private void LogInScreen_Load(object sender, EventArgs e)
    {

    }
  }
}
