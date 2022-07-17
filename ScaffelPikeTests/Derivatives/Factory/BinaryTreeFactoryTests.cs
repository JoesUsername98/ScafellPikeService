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
      //assert
      var exMin = d == -1 ? So * Math.Pow(u, -N) : So * Math.Pow(d, N);
      Assert.Equal(tree.Count, Enumerable.Range(0, N + 1).Sum(i => Combinations.summedNCR(i)));
      Assert.Equal(So * Math.Pow(u, N), tree.MaxInTree().Select(n => n.Data).Max());
      Assert.Equal(exMin, tree.MinInTree().Select(n => n.Data).Min());
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

      // ...populate tree (left as an exercise)

      // Define the Action to perform on each node.
      Action<double> myAction = x => x = Math.Max(k - x, 0); ///|K-s|

      // Traverse the tree with parallel tasks.
      DoTree(tree.GetAt(new bool[] { }), myAction);
    }
    // By using tasks explcitly.
    private static void DoTree<T>(Node<T> node, Action<T> action) where T : IComparable<T>
    {
      if (node == null) return;
      var left = Task.Factory.StartNew(() => DoTree(node.Tails, action));
      var right = Task.Factory.StartNew(() => DoTree(node.Heads, action));
      action(node.Data); //TODO how out how to get the action to modify the data 
      try
      {
        Task.WaitAll(left, right);
      }
      catch (AggregateException)
      {
        //handle exceptions here
      }
    }
  }
}
