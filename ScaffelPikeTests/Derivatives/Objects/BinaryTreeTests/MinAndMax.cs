using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ScaffelPikeTests.Derivatives.Objects.BinaryTreeTests
{
  public class MinAndMax
  {
 
    [Theory]
    [InlineData(1, 2, 3, 4, 5, 6, 7)]
    [InlineData(2, 2, 3, 4, 7, 6, 7)]
    [InlineData(-1, 0, 3, 9, 5, 6, 7)]
    [InlineData(19, 2, 3, 4, 18, 6, 7)]
    public void TestMaxInTree(int data1, int data2, int data3, int data4, int data5, int data6, int data7)
    {
      //arrange
      var data = new List<int>() { data1, data2, data3, data4, data5, data6, data7 };
      var bt = BinaryTreeTestFactory.GenerateTimeTwoTree(data);
      //act and assert
      Assert.Equal(data.Max(), bt.MaxInTree().First().Data);
      Assert.Equal(data.Count(d => d == data.Max()), bt.MaxInTree().Count());
    }

    [Theory]
    [InlineData(1, 2, 3, 4, 5, 6, 7)]
    [InlineData(2, 2, 3, 4, 7, 6, 7)]
    [InlineData(-1, 0, 3, 9, 5, 6, 7)]
    [InlineData(19, 2, 3, 4, 18, 6, 7)]
    public void TestMinInTree(int data1, int data2, int data3, int data4, int data5, int data6, int data7)
    {
      //arrange
      var data = new List<int>() { data1, data2, data3, data4, data5, data6, data7 };
      var bt = BinaryTreeTestFactory.GenerateTimeTwoTree(data);
      //act and assert
      Assert.Equal(data.Min(), bt.MinInTree().First().Data);
      Assert.Equal(data.Count(d => d == data.Min()), bt.MinInTree().Count());
    }
  }
}
