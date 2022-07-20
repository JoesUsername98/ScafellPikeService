using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Objects
{
  public class ExpectableState : IEquatable<ExpectableState>
  {
    public double PayOff { get; set; }
    public double InterestRate { get; set; }

    public bool Equals(ExpectableState other)
    {
      return PayOff == other.PayOff &&
              InterestRate == other.InterestRate;
    }
  }
}
