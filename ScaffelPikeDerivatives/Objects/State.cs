using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Objects
{
  public class State : IEquatable<State>
  {
    public double Security { get; set; }
    public double PayOff { get; set; }
    public double DiscountRate { get; set; }

    public bool Equals(State other)
    {
      return Security == other.Security && PayOff == other.PayOff && DiscountRate == other.DiscountRate;
    }
  }
}
