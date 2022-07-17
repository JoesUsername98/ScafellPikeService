using System;
using System.Collections.Generic;

namespace ScaffelPikeDerivatives.Objects.Interfaces
{
  public interface INode<T> : ICloneable, IEnumerable<Node<T>> where T : IComparable<T>
  {
    T Data { get; }
    Node<T> Heads { get; set; }
    bool[] Path { get; }
    Node<T> Previous { get; set; }
    Node<T> Tails { get; set; }
    int Time { get; }
    int CountSubsequentNodes(Node<T> node);
    int CountTime(Node<T> node);
    Node<T> GetNext(bool isHeads);
    IEnumerable<Node<T>> MaxInPath();
    IEnumerable<Node<T>> MinInPath();
  }
}