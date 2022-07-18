using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Factory;
using ScaffelPikeDerivatives.Objects;
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
      var maxValueInTree = tree.Max(x => x.Data.Value);
      var minValueInTree = tree.Min(x => x.Data.Value);

      //assert
      var exMin = d == -1 ? So * Math.Pow(u, -N) : So * Math.Pow(d, N);
      Assert.Equal(tree.Count, Enumerable.Range(0, N + 1).Sum(i => Combinations.summedNCR(i)));
      Assert.Equal(So * Math.Pow(u, N), maxValueInTree);
      Assert.Equal(exMin, minValueInTree);
    }

    [Fact]
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-traverse-a-binary-tree-with-parallel-tasks
    /// </summary>
    public void practicingPredicatingTree()
    {
      //arrange 
      int So = 4;
      int N = 2;
      double u = 2;
      double k = 5;
      //act 
      var tree = BinaryTreeFactory.CreateSecurityTree(So, N, u);

      // Define the Action to perform on each node.
      Func<Node<State>, double, double> myFunc = (x,K) => Math.Max(K - x.Data.Value, 0); ///|K-s|

      foreach (var node in tree)
      {
        node.Data.PayOff = myFunc(node, k);
      }

      //foreach(var node in tree)
      //{
      //  var discountRate = 0.25; 
      //  var expected = (1/(1+discountRate))(p.node.Data
      //  node.Data = myFunc(node, k);
      //}
    }

  }
}
