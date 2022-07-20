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
    private double _probabilityHeads;
    public double ProbabilityHeads {
      get { return _probabilityHeads; }
      set {
        if (value <= 0) throw new InvalidOperationException("probabilty cannot be <= 0");
        if (value >= 1) throw new InvalidOperationException("probabilty cannot be >= 0");

        _probabilityHeads = value;
      } 
    }
    public double ProbabilityTails { get { return 1 - ProbabilityHeads; } }
    public State Expected { get; set; }
    public bool Equals(State other)
    {
      return Value == other.Value &&
              ProbabilityHeads == other.ProbabilityHeads &&
              PayOff == other.PayOff &&
              InterestRate == other.InterestRate &&
              Expected == other.Expected;
    }
  }
}
