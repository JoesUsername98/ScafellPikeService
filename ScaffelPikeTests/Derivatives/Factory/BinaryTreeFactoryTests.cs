using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using Xunit;

namespace ScaffelPikeTests.Derivatives.Factory
{
  public class BinaryTreeFactoryTests
  {
    [Theory]
    [InlineData(4, 3, 2)]
    [InlineData(4, 10, 2)]
    [InlineData(4, 2, 1.1)]
    [InlineData(4, 3, 2, 0.33)]
    [InlineData(4, 10, 2, 0.8)]
    [InlineData(4, 2, 1.1 , 0.1)]

    public void GeneratePathCombinationsForTime(int So, int N, double u, double d = -1)
    {
      //arrange 

      //act 
      var tree = d == -1 ? BinaryTreeFactory.CreateSecurityTree(So, N, u) : BinaryTreeFactory.CreateSecurityTree(So, N, u, d);
      //assert
      var exMin = d == -1 ? So * Math.Pow(u, -N) : So * Math.Pow(d, N);
      Assert.Equal(tree.Count, Enumerable.Range(0, N + 1).Sum(i => Combinations.summedNCR(i)));
      Assert.Equal(So * Math.Pow(u, N), tree.MaxInTree().Select(n => n.Data).Max());
      Assert.Equal(exMin, tree.MinInTree().Select(n => n.Data).Min());
    }
  }
}
