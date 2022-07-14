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
    public void GeneratePathCombinationsForTime(int So, int N, double u)
    {
      //arrange 

      //act 
      var tree = BinaryTreeFactory.CreateSecurityTree(So, N, u);
      //assert
      Assert.Equal(tree.Count, Enumerable.Range(0, N + 1).Sum(i => Combinations.summedNCR(i)));
      Assert.Equal(So * Math.Pow(u, N), tree.MaxInTree().Select(n => n.Data).Max());
      Assert.Equal(So * Math.Pow(u, -N), tree.MinInTree().Select(n => n.Data).Min());
    }
  }
}
