﻿using System.Collections.Generic;
using ScaffelPikeDerivatives.Objects;

namespace ScaffelPikeTests.Derivatives.Objects
{
  public static class BinaryTreeTestFactory
  {
    public static BinaryTree<string> GenerateTimeTwoTree()
    {
      //arrange
      var bt = new BinaryTree<string>();
      bt.Add(new Node<string>("root", new bool[] { }));
      bt.Add(new Node<string>("h", new bool[] { true }));
      bt.Add(new Node<string>("t", new bool[] { false }));
      bt.Add(new Node<string>("hh", new bool[] { true, true }));
      bt.Add(new Node<string>("ht", new bool[] { true, false }));
      bt.Add(new Node<string>("tt", new bool[] { false, false }));
      bt.Add(new Node<string>("th", new bool[] { false, true }));
      return bt;
    }
    public static BinaryTree<int> GenerateTimeTwoTree(List<int> data)
    {
      //arrange
      var bt = new BinaryTree<int>();
      bt.Add(new Node<int>(data[0], new bool[] { }));
      bt.Add(new Node<int>(data[1], new bool[] { true }));
      bt.Add(new Node<int>(data[2], new bool[] { false }));
      bt.Add(new Node<int>(data[3], new bool[] { true, true }));
      bt.Add(new Node<int>(data[4], new bool[] { true, false }));
      bt.Add(new Node<int>(data[5], new bool[] { false, false }));
      bt.Add(new Node<int>(data[6], new bool[] { false, true }));
      return bt;
    }

    public static BinaryTree<int> GenerateHeadsOnlyTree(List<int> data)
    {
      //arrange
      var bt = new BinaryTree<int>();
      bt.Add(new Node<int>(data[0], new bool[] { }));
      bt.Add(new Node<int>(data[1], new bool[] { true }));
      bt.Add(new Node<int>(data[2], new bool[] { true, true }));
      bt.Add(new Node<int>(data[3], new bool[] { true, true, true }));
      bt.Add(new Node<int>(data[4], new bool[] { true, true, true, true }));
      bt.Add(new Node<int>(data[5], new bool[] { true, true, true, true, true }));
      bt.Add(new Node<int>(data[6], new bool[] { true, true, true, true, true, true }));
      return bt;
    }
  }
}
