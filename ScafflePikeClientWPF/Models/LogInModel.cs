namespace ScafellPikeClientWPFOld.Models
{
  public class LogInModel
  {
    public LogInModel()
    {
      Username = "";
      Password = "";
      Connections = 0;
    }
    public LogInModel(string username, string password, int connections)
    {
      Username = username;
      Password = password;
      Connections = connections;
    }
    private string _Username;
    public string Username 
    { 
      get { return _Username; }
      set { _Username = value;}
    }
    
    private string _Password;
    public string Password 
    { 
      get { return _Password; } 
      set { _Password = value; } 
    }

    private int _Connections;
    public int Connections 
    { 
      get { return _Connections; } 
      set { _Connections = value; } 
    }
    
  }
}
