using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects;

namespace ScaffelPikeDerivatives.Factory
{
  public static class BinaryTreeFactory
  {
    public static BinaryTree<decimal> CreateSecurityTree(decimal initialPrice, int time, decimal upFactor)
    {
      if (upFactor == 0) throw new ArgumentException("upFactor cannot be 0", "upFactor");
      
      return CreateSecurityTree(initialPrice, time, upFactor, 1 / upFactor);
    }
    public static BinaryTree<decimal> CreateSecurityTree(decimal initialPrice, int time, decimal upFactor, decimal downFactor)
    {
      if (time < 0) throw new ArgumentException("time cannot be less than 0", "time");
      if (initialPrice < 0) throw new ArgumentException("initialPrice cannot be 0", "initialPrice");
      if (upFactor == 0) throw new ArgumentException("upFactor cannot be 0", "upFactor");
      if (downFactor == 0) throw new ArgumentException("downFactor cannot be 0", "downFactor");

      var bt = new BinaryTree<decimal>(new Node<decimal>(initialPrice, new bool[] { }));
      for(int currTime = 0; currTime < time + 1; currTime++)
      {
        // get possibilities for tree
      }

      return bt;
    }

  }
}
