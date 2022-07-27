using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScafellPikeDerivatives.Objects;
using ScafellPikeDerivatives.Objects.Interfaces;

namespace ScafellPikeDerivatives.Visitors
{
  public class ConstantInterestRateBinaryTreeEnhancer : IBinaryTreeEnhancer
  {
    private readonly double _constantInterestRate;
    public ConstantInterestRateBinaryTreeEnhancer(double constantInterestRate)
    {
      _constantInterestRate = constantInterestRate;
    }
    public void Enhance(BinaryTree<State> subject)
    {
      foreach (var node in subject)
      {
        node.Data.InterestRate = _constantInterestRate; 
      }
      subject.ConstantInterestRate = _constantInterestRate;
    }
  }
}
