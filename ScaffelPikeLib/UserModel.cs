using System;

namespace ScaffelPikeContracts
{
  public class UserModel: IEquatable<UserModel>
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Boolean Admin { get; set; }

    public bool Equals(UserModel other)
    {
      return
        this.Id == other.Id &&
        this.FirstName == other.FirstName &&
        this.Surname == other.Surname &&
        this.Username == other.Username &&
        this.Password == other.Password;
    }
  }
}
