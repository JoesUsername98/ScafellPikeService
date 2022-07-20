using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects;
using ScaffelPikeDerivatives.Objects.Interfaces;

namespace ScaffelPikeDerivatives.Visitors
{
  public class UnderlyingValueBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly double _initialPrice;
    private readonly double _upFactor;
    private readonly double _downFactor;
    public UnderlyingValueBinaryTreeEnhancer(double initialPrice, double upFactor)
    {
      if (initialPrice < 0) throw new ArgumentException("initialPrice cannot be 0", "initialPrice");
      if (upFactor <= 0) throw new ArgumentException("upFactor cannot be 0 or less", "upFactor");
      if (upFactor < 1/upFactor) throw new ArgumentException("upFactor cannot be less than downFactor");

      _initialPrice = initialPrice;
      _upFactor = upFactor;
      _downFactor = 1/upFactor;
    }
    public UnderlyingValueBinaryTreeEnhancer(double initialPrice, double upFactor, double downFactor)
    {
      if (initialPrice < 0) throw new ArgumentException("initialPrice cannot be 0", "initialPrice");
      if (upFactor <= 0) throw new ArgumentException("upFactor cannot be 0 or less", "upFactor");
      if (downFactor <= 0) throw new ArgumentException("downFactor cannot be 0 or less", "downFactor");
      if (upFactor < downFactor) throw new ArgumentException("upFactor cannot be less than downFactor");

      _initialPrice = initialPrice;
      _upFactor = upFactor;
      _downFactor = downFactor;
    }
    public void Enhance(BinaryTree<State> subject)
    {
      foreach (var node in subject)
      {
        var state = new State();
        var noOfHeads = node.Path.Where(p => p).Count();
        var noOfTails = node.Time - noOfHeads;
        node.Data.Value = _initialPrice * Math.Pow(_upFactor, noOfHeads) * Math.Pow(_downFactor, noOfTails);
      }

      subject.ConstantUpFactor = _upFactor;
      subject.ConstantDownFactor = _downFactor;
    }
  }
}
