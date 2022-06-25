using System;

namespace ScaffelPikeDerivatives.Objects
{
  public interface IBinaryTree<T> where T : IComparable<T>
  {
    int Count { get; set; }
    Node<T> GetAt(bool[] path);
    void Insert(Node<T> newItem);
    Node<T> MaxInTree();
    Node<T> MinInTree();
    void Remove(Node<T> node);
  }
}