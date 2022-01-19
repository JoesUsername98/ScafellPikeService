using System;
using System.Windows.Forms;
using ScaffelPikeContracts;
using ScaffelPikeLogger;

namespace ScaffelPikeClient
{
  public partial class LogInScreen : Form
  {
    private readonly IScaffelPikeService _client;
    private readonly ILogger _logger;
    public LogInScreen(IScaffelPikeService client, ILogger logger)
    {
      InitializeComponent();
      _client = client;
      _logger = logger;
      _logger.Information("LogInScreen", "Initialized Logger");
    }

    private void buttonLogIn_Click(object sender, EventArgs e)
    {
      var username = textBoxUsername.Text;
      var password = textBoxPassword.Text;
      
      _logger.Information("buttonLogIn_Click", $"Log In Attempt with Username [{username}] Passsword [{password}]");
      
      //clean up with awiat and seperate in MVC fashion
      var outputTask = _client.LogIn(username, password);
      outputTask.Wait();
      var output = outputTask.Result;

      _logger.Information("buttonLogIn_Click", $"Log In Attempt Successful {output.Success}");

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
      _logger.Information("LogInScreen_FormClosed", "Closing form");
    }
  }
}
