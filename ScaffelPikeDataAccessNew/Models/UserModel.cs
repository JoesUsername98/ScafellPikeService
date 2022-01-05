using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDataAccess.Models;

public class UserModel
{
  public int Id { get; set; }
  public string FirstName { get; set; }
  public string Surname { get; set; }
  public string Username { get; set; }
  public string Password { get; set; }
}
