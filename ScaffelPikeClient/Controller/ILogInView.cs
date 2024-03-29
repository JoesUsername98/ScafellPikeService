﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScafellPikeClient.Models;

namespace ScafellPikeClient.Controller
{
  public interface ILogInView
  {
    void SetController(LogInController controller);
    void HideView();
    string Username { get; set; }
    string Password { get; set; }
    string Connections { get; set; }
    bool PasswordVisible { get; set; }
  }
}
