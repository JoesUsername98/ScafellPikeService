using System;
using System.Collections.Generic;

namespace ScaffelPikeDerivatives.Objects
{
  public interface IBinaryTree<T> where T : IComparable<T>
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