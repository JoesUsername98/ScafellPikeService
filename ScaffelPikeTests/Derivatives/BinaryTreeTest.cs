using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaffelPikeDerivatives.Objects;
using Xunit;

namespace ScaffelPikeTests.Derivatives
{
  public class BinaryTreeTest
  {
    [Fact]
    public void SetAndGet()
    {
      var bt = new BinaryTree<string>();
      bt.Insert(new Node<string>("root", new bool[] { } ));
      bt.Insert(new Node<string>("h", new bool[] { true } ));
      bt.Insert(new Node<string>("t", new bool[] { false } ));
      bt.Insert(new Node<string>("hh", new bool[] { true, true }));
      bt.Insert(new Node<string>("ht", new bool[] { true, false }));
      bt.Insert(new Node<string>("tt", new bool[] { false, false}));
      bt.Insert(new Node<string>("th", new bool[] { false, true }));

      Assert.Equal("root",bt.GetAt(new bool[] { }).Data);
      Assert.Equal("h", bt.GetAt(new bool[] { true }).Data);
      Assert.Equal("t", bt.GetAt(new bool[] { false }).Data);
      Assert.Equal("hh", bt.GetAt(new bool[] { true, true }).Data);
      Assert.Equal("ht", bt.GetAt(new bool[] { true, false }).Data);
      Assert.Equal("tt", bt.GetAt(new bool[] { false, false }).Data);
      Assert.Equal("th", bt.GetAt(new bool[] { false, true }).Data);
      Assert.Equal(7, bt.Count);
      Assert.Equal(2, bt.Time);
    }

    [Theory]
    [InlineData(1,2,3,4,5,6,7)]
    [InlineData(2, 2, 3, 4, 7, 6, 7)]
    [InlineData(-1, 0, 3, 9, 5, 6, 7)]
    [InlineData(19, 2, 3, 4, 18, 6, 7)]
    public void TestMaxInTree(int data1, int data2, int data3, int data4, int data5, int data6, int data7)
    {
      var data = new List<int>() { data1, data2, data3, data4, data5, data6, data7 };
      var bt = new BinaryTree<int>();
      bt.Insert(new Node<int>(data[0], new bool[] { }));
      bt.Insert(new Node<int>(data[1], new bool[] { true }));
      bt.Insert(new Node<int>(data[2], new bool[] { false }));
      bt.Insert(new Node<int>(data[3], new bool[] { true, true }));
      bt.Insert(new Node<int>(data[4], new bool[] { true, false }));
      bt.Insert(new Node<int>(data[5], new bool[] { false, false }));
      bt.Insert(new Node<int>(data[6], new bool[] { false, true }));

      Assert.Equal(data.Max(), bt.MaxInTree().First().Data);
      Assert.Equal(data.Count(d => d == data.Max()), bt.MaxInTree().Count());
    }

    [Theory]
    //[InlineData(1, 2, 3, 4, 5, 6, 7)]
    //[InlineData(2, 2, 3, 4, 7, 6, 7)]
    //[InlineData(-1, 0, 3, 9, 5, 6, 7)]
    [InlineData(19, 2, 3, 4, 18, 6, 7)]
    public void TestMinInTree(int data1, int data2, int data3, int data4, int data5, int data6, int data7)
    {
      var data = new List<int>() { data1, data2, data3, data4, data5, data6, data7 };
      var bt = new BinaryTree<int>();
      bt.Insert(new Node<int>(data[0], new bool[] { }));
      bt.Insert(new Node<int>(data[1], new bool[] { true }));
      bt.Insert(new Node<int>(data[2], new bool[] { false }));
      bt.Insert(new Node<int>(data[3], new bool[] { true, true }));
      bt.Insert(new Node<int>(data[4], new bool[] { true, false }));
      bt.Insert(new Node<int>(data[5], new bool[] { false, false }));
      bt.Insert(new Node<int>(data[6], new bool[] { false, true }));

      Assert.Equal(data.Min(), bt.MinInTree().First().Data);
      Assert.Equal(data.Count(d => d == data.Min()), bt.MinInTree().Count());
    }

    [Fact]
    public void Remove()
    {
      var bt = new BinaryTree<string>();
      var theNodeToRemove = new Node<string>("t", new bool[] { false });
      bt.Insert(new Node<string>("root", new bool[] { }));
      bt.Insert(new Node<string>("h", new bool[] { true }));
      bt.Insert(theNodeToRemove);
      bt.Insert(new Node<string>("hh", new bool[] { true, true }));
      bt.Insert(new Node<string>("ht", new bool[] { true, false }));
      bt.Insert(new Node<string>("tt", new bool[] { false, false }));
      bt.Insert(new Node<string>("th", new bool[] { false, true }));
      bt.Remove(theNodeToRemove);

      //TODO
      Assert.Equal(6, bt.Count);
      Assert.Equal(2, bt.Time);
    }
  }
}
