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

      //
      Assert.Equal(6, bt.Count);
      Assert.Equal(2, bt.Time);
    }
  }
}
