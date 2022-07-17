using System;
using System.Collections;
using System.Collections.Generic;

namespace ScaffelPikeDerivatives.Objects.Interfaces
{
  public interface IBinaryTree<T> : ICloneable, IEnumerable<Node<T>> where T : IComparable<T>
  {
    int Count { get; }
    int Time  { get; }
    Node<T> GetAt(bool[] path);
    void Insert(Node<T> newItem);
    IEnumerable<Node<T>> MaxInTree();
    IEnumerable<Node<T>> MinInTree();
    void Remove(Node<T> node);
  }
}