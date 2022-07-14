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
    public static BinaryTree<double> CreateSecurityTree(double initialPrice, int time, double upFactor)
    {
      if (upFactor == 0) throw new ArgumentException("upFactor cannot be <= 0", "upFactor");
      
      return CreateSecurityTree(initialPrice, time, upFactor, 1 / upFactor);
    }
    public static BinaryTree<double> CreateSecurityTree(double initialPrice, int time, double upFactor, double downFactor)
    {
      if (time < 0) throw new ArgumentException("time cannot be less than 0", "time");
      if (initialPrice < 0) throw new ArgumentException("initialPrice cannot be 0", "initialPrice");
      if (upFactor == 0) throw new ArgumentException("upFactor cannot be 0", "upFactor");
      if (downFactor == 0) throw new ArgumentException("downFactor cannot be 0", "downFactor");
      if (upFactor < downFactor) throw new ArgumentException("upFactor cannot be less than downFactor");

      var bt = new BinaryTree<double>(new Node<double>(initialPrice, new bool[] { }));
      for(int currTime = 1; currTime <= time ; currTime++)
      {
        var inputParams = Combinations.GenerateParams(new bool[] { true, false }, currTime);
        foreach (IEnumerable<bool> path in Combinations.Parameters(inputParams))
        {
          var noOfHeads = (double)path.Where(p => p).Count();
          var price = (double)initialPrice * Math.Pow( upFactor, noOfHeads) * Math.Pow((double)downFactor, (double)(currTime - noOfHeads));
          bt.Insert(new Node<double>((double)price, path.ToArray()));
        };
      }
      return bt;
    }

  }
}
