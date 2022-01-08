using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScaffelPikeClient.ScaffelPikeServiceReference;

namespace ScaffelPikeClient
{
  public partial class LogInScreen : Form
  {
    private readonly ScaffelPikeServiceClient _client;
    public LogInScreen(ScaffelPikeServiceClient client)
    {
      InitializeComponent();
      _client = client;
    }

    private void buttonLogIn_Click(object sender, EventArgs e)
    {
      var username = textBoxUsername.Text;
      var password = textBoxPassword.Text;
      var output = _client.LogIn(username, password);

      if (output.Success)
        MessageBox.Show($"Welcome {output.OtherData}", "Log in Success", MessageBoxButtons.OK);
      else
        MessageBox.Show($"Who do you think you are?", "Log in Failed", MessageBoxButtons.OK);
    }

    private void LogInScreen_Load(object sender, EventArgs e)
    {
      //Inits
    }
  }
}
