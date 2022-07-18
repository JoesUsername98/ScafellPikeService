using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeDerivatives.Objects
{
  public class State : ExpectableState, IEquatable<State>
  {
    public double Value { get; set; }
    public double ProbabilityHeads { get; set; }
    public State Expected { get; set; }
    public bool Equals(State other)
    {
      return Value == other.Value &&
              ProbabilityHeads == other.ProbabilityHeads &&
              PayOff == other.PayOff &&
              DiscountRate == other.DiscountRate &&
              Expected == other.Expected;
    }
  }
}
