using System;
using System.Collections;
using System.Collections.Generic;

namespace ScaffelPikeDerivatives.Objects.Interfaces
{
  public interface IBinaryTree<T> : ICloneable, ICollection<Node<T>>, IEnumerable<Node<T>> where T : IComparable<T>
  {
    int Time  { get; }
    Node<T> GetAt(bool[] path);
    IEnumerable<Node<T>> MaxInTree();
    IEnumerable<Node<T>> MinInTree();
  }
}